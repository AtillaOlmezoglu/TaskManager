import { BrowserRouter as Router, Routes, Route } from 'react-router-dom'
import './App.css'
import { routes } from './routes'

function App() {
  return (
    <div>
      <Router>
        <Routes>
          <Route path='/'>
            {routes.map((route) => (
              <Route 
                key={route.key}
                path={route.path}
                element={<route.component />}
              />
            ))}
          </Route>
        </Routes>
      </Router>
    </div>
  )
}

export default App
