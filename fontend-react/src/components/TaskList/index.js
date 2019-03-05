import React, { Component } from 'react';
import TaskListItem from '../TaskListItem';
import TaskListForm from '../TaskListForm';
import Ajax from '../../Ajax';

class TaskList extends Component {
    constructor(props) {
        super(props);
        this.todoItems = props.initItems;

        this.state = { todoItems: this.todoItems };

        Ajax.get('Tasklist')
            .then((response) => {
                this.setState({
                    todoItems: response.data
                });
                this.todoItems = response.data;
            })
            .catch(function (error) {
                console.log(error);
            });

        this.addItem = this.addItem.bind(this);
        this.removeItem = this.removeItem.bind(this);
        this.setDone = this.setDone.bind(this);
    }

    addItem(todoItem) {
        Ajax.post('Tasklist', todoItem)
            .then((response) => {
                todoItem.id = response.data;
                this.todoItems.push(todoItem);
                this.setState({ todoItems: this.todoItems });
            })
            .catch(function (error) {
                console.log(error);
            });
    }

    getElementIndex(id) {
        let toRemove = -1;
        this.todoItems.map((element, index) => {
            if (element.id === id) toRemove = index;
        });
        return toRemove;
    }

    removeItem(id) {
        let toRemove = this.getElementIndex(id);
        if (toRemove === -1) return;

        Ajax.delete(`Tasklist/${id}`)
            .then((response) => {
                this.todoItems.splice(toRemove, 1);
                this.setState({ todoItems: this.todoItems });
            })
            .catch(function (error) {
                console.log(error);
            });
    }

    setDone(id) {
        let index = this.getElementIndex(id);
        if (index === -1) return;

        Ajax.put(`Tasklist/AlterarStatus/${id}`)
            .then((response) => {
                var todo = this.todoItems[index];
                todo.concluido = !todo.concluido;
                this.setState({ todoItems: this.todoItems });
            })
            .catch(function (error) {
                console.log(error);
            });
    }

    render() {
        var items = this.state.todoItems.map((item, index) => {
            return (
                <TaskListItem key={index} item={item} removeItem={this.removeItem} setDone={this.setDone} />
            );
        });
        return (
            <div id="main">
                <ul className="list-group"> {items} </ul>
                <TaskListForm addItem={this.addItem} />
            </div>
        );
    }

}
export default TaskList;