import React, { Component } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { actionCreators } from '../store/BattleshipsStore';

Array.prototype.firstRow = function () {
    if (this === null || this.length === 0)
        return [];

    return this[0];
};

@deferLoader((props, store) => store.dispatch(loadUsers(props)))
@connect({ ... }, { ... })
class BattleshipsComponent extends Component {
    componentDidMount() {
        // This method is called when the component is first added to the document
        this.ensureDataFetched();
    }

    componentDidUpdate() {
        // This method is called when the route parameters change
        this.ensureDataFetched();
    }

    ensureDataFetched() {
        this.props.requestBoard();
    }

    render() {
        return (
            <div>
                <h1>Battleships</h1>
                {renderBoard(this.props)}
            </div>
        );
    }
}

function renderBoard(props) {
    const letters = new Array(26)
        .fill(1)
        .map((_, i) => String.fromCharCode(97 + i));

    return (
        <table className='table'>
            <thead>
                <tr>
                    <th />
                    {props.board
                        .firstRow()
                        .map((item, index) =>
                            <th>{letters[index]}</th>
                        )
                    }
                </tr>
            </thead>
            <tbody>
                {props.board
                    .map((row, index) =>
                        <tr>
                            <th>{index}</th>
                            {row.map(item => <td>item</td>)}
                        </tr>
                    )}
            </tbody>
        </table>
    );
}

export default connect(
    state => state.battleshipBoard,
    dispatch => bindActionCreators(actionCreators, dispatch)
)(BattleshipsComponent);
