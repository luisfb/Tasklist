import React, { Component } from 'react';
import TaskList from './components/TaskList';
import './App.css';

class App extends Component {
  
  render() {
    let todoItems = [
      {
        "id": 1,
        "titulo": "Hardcoded Task 1",
        "descricao": "Descrição Task 1",
        "concluido": false,
        "criacao": "2019-03-04T07:52:57.8375448-03:00",
        "erros": []
      },
      {
        "id": 2,
        "titulo": "Hardcoded Task 2",
        "descricao": "Descrição Task 2",
        "concluido": false,
        "criacao": "2019-03-04T07:52:57.8375448-03:00",
        "erros": []
      },
      {
        "id": 3,
        "titulo": "Hardcoded Task 3",
        "descricao": "Descrição Task 3",
        "concluido": true,
        "criacao": "2019-03-04T07:52:57.8375448-03:00",
        "erros": []
      }
    ];
    return (
      <div className="App">
        <TaskList initItems={todoItems}/>
      </div>
    ); 
  }
}

export default App;
