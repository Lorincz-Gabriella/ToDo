using AutoMapper;
using Azure;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Threading.Tasks;
using ToDo.Application.DTOs;
using ToDo.Application.Services.Interfaces;

namespace FunctionsApi;

//endpoint=egy URL-cím, amin keresztül a kliens kérni tud valamit az API-tól
public class ToDoFunction
{
    private readonly ILogger<ToDoFunction> _logger;
    private readonly IToDoService _service;

    public ToDoFunction(ILogger<ToDoFunction> logger,IToDoService service)
    {
        _logger = logger;
        _service = service;
    }

    [Function("ToDoFunction")]
    public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");
        return new OkObjectResult("Welcome to Azure Functions!");
    }


    [Function("GetAllToDoItems")]
    //[OpenApiOperation(operationId :"",tags: ["ToDo"],Summary="",Description ="")]
    public IActionResult GetAllToDoItems([HttpTrigger(AuthorizationLevel.Anonymous, "get",Route="todos")] HttpRequest req)
    {
        _logger.LogInformation("Triger function processesed GetAllToDoItems request");
        var items=_service.GetAllToDos();
        return new OkObjectResult(items);
    }

    [Function("GetAllToDoItemsAsync")]
    public async Task<IActionResult> GetAllToDoItemsAsync([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "v2/todos")] HttpRequest req)
    {
        _logger.LogInformation("Triger function processesed GetAllToDoItems request");
        var items =await  _service.GetAllToDosAsync();
        return new OkObjectResult(items);
    }


    [Function("GetToDoById")]
    public IActionResult GetToDoById([HttpTrigger(AuthorizationLevel.Anonymous,"get",Route ="todos/{id}")] HttpRequest req,Guid id)
    {
        _logger.LogInformation($"GetToDoById with {id} processed a request ");
        var item = _service.GetToDoById(id);
        return new OkObjectResult(item);
    }

    [Function("GetToDoByIdAsync")]
    public async Task<IActionResult> GetToDoByIdAsync([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "v2/todos/{id}")] HttpRequest req, Guid id)
    {
        _logger.LogInformation($"GetToDoById with {id} processed a request ");
        var item = await _service.GetToDoByIdAsync(id);
        return new OkObjectResult(item);
    }


    [Function("AddToDoToDB")]
    public async Task<IActionResult> AddToDoToDB([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "todos")] HttpRequest req)
    {
        try
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync(); //megvarjuk mig a szal lefut s utanna folytassa a foszal amit mas hasznalhat
            _logger.LogInformation($"GetToDoById with details:({requestBody}) processed a request ");
            var createDTO = JsonConvert.DeserializeObject<CreateToDoItemDTO>(requestBody); //string -> DTO
            if (createDTO != null)
            {
                var item = _service.AddToDoToDB(createDTO);
                return new OkObjectResult(item);
            }else 
            {
                return new BadRequestObjectResult("missing body parameter");
            }
        }
        catch (ValidationException ex)
        {
            return new BadRequestObjectResult(ex.Errors);
        }
        catch (Exception ex)
        {
            return new ObjectResult(ex)
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };
        }
    }

    [Function("AddToDoToDBAsync")]
    public async Task<IActionResult> AddToDoToDBAsync([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "v2/todos")] HttpRequest req)
    {
        try
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            _logger.LogInformation($"GetToDoById with details:({requestBody}) processed a request ");
            var createDTO = JsonConvert.DeserializeObject<CreateToDoItemDTO>(requestBody);
            if (createDTO != null)
            {
                var item = await _service.AddToDoToDBAsync(createDTO);
                return new OkObjectResult(item);
            }
            else 
            {
                return new BadRequestObjectResult("missing body parameter");
            }
            ;
        }
        catch (ValidationException ex)
        {
            return new BadRequestObjectResult(ex.Errors);
        }
        catch (Exception ex)
        {
            return new ObjectResult(ex)
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };
        }
    }

    [Function("DeleteToDo")]
    public IActionResult DeleteToDo([HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "todos/{id}")] HttpRequest req, Guid id)
    {
        _logger.LogInformation($"UpdateToDo with {id} processed a request ");
        var item = _service.DeleteToDo(id);
        return new OkObjectResult(item);
    }

    [Function("DeleteToDoAsync")]
    public async Task<IActionResult> DeleteToDoAsync([HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "v2/todos/{id}")] HttpRequest req, Guid id)
    {
        _logger.LogInformation($"UpdateToDo with {id} processed a request ");
        var item = await _service.DeleteToDoAsync(id);
        return new OkObjectResult(item);
    }


    [Function("UpdateToDo")]
    public async Task<IActionResult> UpdateToDo([HttpTrigger(AuthorizationLevel.Anonymous, "patch", Route = "todos/{id}")] HttpRequest req, Guid id)
    {
        try
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var updateDTO = JsonConvert.DeserializeObject<UpdateToDoItemDTO>(requestBody);
            if (updateDTO != null)
            {
                _logger.LogInformation($"DeleteToDo with details:({requestBody}) and with id {id} processed a request ");
                var item = _service.UpdateToDo(id, updateDTO);
                return new OkObjectResult(item);
            }
            else
            {
                return new BadRequestObjectResult("missing body parameter");
            }
            }
        catch (Exception ex)
        {
            return new ObjectResult(ex)
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };
        }
    }

    [Function("UpdateToDoAsync")]
    public async Task<IActionResult> UpdateToDoAsync([HttpTrigger(AuthorizationLevel.Anonymous, "patch", Route = "v2/todos/{id}")] HttpRequest req, Guid id)
    {
        try
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var updateDTO = JsonConvert.DeserializeObject<UpdateToDoItemDTO>(requestBody);
            if (updateDTO != null)
            {
                _logger.LogInformation($"DeleteToDo with details:({requestBody}) and with id {id} processed a request ");
                var item = await _service.UpdateToDoAsync(id, updateDTO);
                return new OkObjectResult(item);
            }
            else return new BadRequestObjectResult("missing body parameter");
        }
        catch (Exception ex)
        {
            return new ObjectResult(ex)
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };
        }
    }
}