import React, { Component } from 'react';

class TaskListForm extends Component {
    constructor(props) {
        super(props);
        this.onSubmit = this.onSubmit.bind(this);
    }
    componentDidMount() {
        this.refs.titulo.focus();
    }
    onSubmit(event) {
        event.preventDefault();
        let task = {
            titulo: this.refs.titulo.value
        };
        if (task.titulo) {
            this.props.addItem(task);
            this.refs.form.reset();
        }
    }
    render() {
        return (
            <form ref="form" onSubmit={this.onSubmit} className="form-inline">
                <input type="text" ref="titulo" className="form-control" placeholder="Nova tarefa..." />
                <button type="submit" className="btn btn-default">Adicionar</button>
            </form>
        );
    }
}

export default TaskListForm;