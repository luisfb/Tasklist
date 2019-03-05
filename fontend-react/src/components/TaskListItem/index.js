import React, { Component } from 'react';

class TaskListItem extends Component {

  constructor(props) {
    super(props);
    this.onClickClose = this.onClickClose.bind(this);
    this.onClickDone = this.onClickDone.bind(this);
  }

  onClickClose() {
    this.props.removeItem(this.props.item.id);
  }
  
  onClickDone() {
    this.props.setDone(this.props.item.id);
  }

  render() {
    var todoClass = this.props.item.concluido ? "done" : "undone";
    return (
      <li className="list-group-item ">
        <div className={todoClass}>
          <span className="glyphicon glyphicon-ok icon" aria-hidden="true" onClick={this.onClickDone}></span>
          {this.props.item.titulo}
          <button type="button" className="close" onClick={this.onClickClose}>&times;</button>
        </div>
      </li>
    );
  }
}


export default TaskListItem;