const BattleshipsDispatchTypes = Object.freeze({
    requestStrike: "REQUEST_STRIKE",
    receiveStrike: "RECEIVE_STRIKE",
    requestBoard: "REQUEST_BOARD",
    receiveBoard: "RECEIVE_BOARD"
});

const initialState = { board: [], isLoading: false };

export const actionCreators = {
    requestBoard: () => async (dispatch, getState) => {
        let state = getState().battleshipBoard;
        if (!state.isLoading && state.board === []) {
            // Don't issue a duplicate request (we already have or are loading the requested data)
            return;
        }

        dispatch({ type: BattleshipsDispatchTypes.requestBoard });

        const url = `api/Battleship/Board`;
        const response = await fetch(url);
        const board = await response.json();

        dispatch({ type: BattleshipsDispatchTypes.receiveBoard, board });
    }
};

export const reducer = (state, action) => {
    state = state || initialState;

    if (action.type === BattleshipsDispatchTypes.requestBoard) {
        return {
            ...state,
            board: [],
            isLoading: true
        };
    }

    if (action.type === BattleshipsDispatchTypes.receiveBoard) {
        return {
            ...state,
            board: action.board,
            isLoading: false
        };
    }

    return state;
};
