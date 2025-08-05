using AutoMapper;
using FluentValidation;
using ToDo.Application.DTOs;
using ToDo.Application.Services.Interfaces;
using ToDo.Application.Validation;
using ToDo.Core.Entity;
using ToDo.Core.Interfaces;

namespace ToDo.Application.Services
{
    public class ToDoService : IToDoService
    {
        private readonly IToDoRespository _repository; //private _ +kicsi betu
        private readonly IMapper _mapper;
        private readonly IValidator<CreateToDoItemDTO> _createValidator;
        private readonly IValidator<UpdateToDoItemDTO> _updateValidator;


        public ToDoService(IToDoRespository rep,IMapper map,CreateToDoItemValidator createValidator, UpdateToDoItemValidator updateValidator)
        {
            _repository = rep;
            _mapper = map;
            _createValidator = createValidator;
            _updateValidator = updateValidator;

        }

        public GetToDoItemDTO AddToDoToDB(CreateToDoItemDTO dto)
        {
            _createValidator.ValidateAndThrow(dto);
            var newToDoItem = _mapper.Map<ToDoItem>(dto);
            var createdToDo = _repository.AddToDoToDB(newToDoItem);  //repo szimpla todot var
            return _mapper.Map<GetToDoItemDTO>(createdToDo);
        }

        public async Task<GetToDoItemDTO> AddToDoToDBAsync(CreateToDoItemDTO dto)
        {
            await  _createValidator.ValidateAndThrowAsync(dto);
            var newToDoItem = _mapper.Map<ToDoItem>(dto);
            var createdToDo = await _repository.AddToDoToDBAsync(newToDoItem);
            return  _mapper.Map<GetToDoItemDTO>(createdToDo);
        }

        public bool DeleteToDo(Guid id)
        {
           return _repository.DeleteToDo(id);
        }

        public async Task<bool> DeleteToDoAsync(Guid id)
        {
            return await _repository.DeleteToDoAsync(id);
        }

        public IEnumerable<GetToDoItemDTO> GetAllToDos()
        {
            var ToDos = _repository.GetAllToDos();
            return  _mapper.Map<IEnumerable<GetToDoItemDTO>>(ToDos);
        }

        public async Task<IEnumerable<GetToDoItemDTO>> GetAllToDosAsync()
        {
            var ToDos =await _repository.GetAllToDosAsync();
            return _mapper.Map<IEnumerable<GetToDoItemDTO>>(ToDos);
        }

        public GetToDoItemDTO? GetToDoById(Guid id)
        {
            var ToDo=_repository.GetToDoById(id);
            if(ToDo == null)
            {
                return null;
            }
            return _mapper.Map<GetToDoItemDTO>(ToDo);
        }

        public async  Task<GetToDoItemDTO?> GetToDoByIdAsync(Guid id)
        {
            var ToDo = await _repository.GetToDoByIdAsync(id);
            if (ToDo == null)
            {
                return null;
            }
            return _mapper.Map<GetToDoItemDTO>(ToDo);
        }

        public bool UpdateToDo(Guid id, UpdateToDoItemDTO toDoItem)
        {

            _updateValidator.ValidateAndThrow(toDoItem);
            var ToDoItem= _mapper.Map<ToDoItem>(toDoItem);
            ToDoItem.Id = id;
            return _repository.UpdateToDo(ToDoItem);
        }

        public async Task<bool> UpdateToDoAsync(Guid id, UpdateToDoItemDTO toDoItem)
        {
            _updateValidator.ValidateAndThrow(toDoItem);
            var ToDoItem = _mapper.Map<ToDoItem>(toDoItem);
            ToDoItem.Id = id;
            return await _repository.UpdateToDoAsync(ToDoItem);
        }
    }
}
