import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import './index.css'
import App from './App.jsx'
import { QueryClient, QueryClientProvider } from '@tanstack/react-query'

const client=new QueryClient({ //kliens a lekerdezeshez
  defaultOptions : {
    queries : {
      staleTime : 1000*60*5, //az adat 5 percig friss(nem valtoztassa ha nem eri querry)
      cacheTime : 1000*60*10,
      retry : 1 //megegyszer megprobalja ha nem sikerul
    }
  }
});

//<komponens + props(properties) >
//app a korulote levo clientProviderbol tudja a  klienst
createRoot(document.getElementById('root')).render(
  <StrictMode>
    <QueryClientProvider  client={client}> 
          <App />
    </QueryClientProvider>
  </StrictMode>,
)
