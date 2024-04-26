import { State, Action, StateContext, Selector } from '@ngxs/store';
import { tap } from 'rxjs/operators';
import { Injectable } from '@angular/core';
import { ExecutionTaskItem } from '../models/executionTaskItem.model';
import { ExecutionTaskItemsService } from '../services/executionTaskItems.service';
import { AddExecutionTaskItem, GetExecutionTaskItems, UpdateExecutionTaskItem } from '../actions/executionTaskItem.action';

export class ExecutionTaskItemStateModel {
    executionTaskItems: ExecutionTaskItem[];
    selectedExecutionTaskItem: ExecutionTaskItem;
}
@Injectable()
@State<ExecutionTaskItemStateModel>({
    name: 'executionTaskItems',
    defaults: {
        executionTaskItems: [],
        selectedExecutionTaskItem: { cronExpression: '', headers:'',taskItemId:0, webUrl: '', id: 0, dateAdded: new Date() }
    }
})
export class ExecutionTaskItemState {

    constructor(private executionTaskItemsService: ExecutionTaskItemsService) {
    }

    @Selector()
    static getExecutionTaskItemList(state: ExecutionTaskItemStateModel) {
        return state.executionTaskItems;
    }

    @Selector()
    static getSelectedExecutionTaskItem(state: ExecutionTaskItemStateModel) {
        return state.selectedExecutionTaskItem;
    }

    @Action(GetExecutionTaskItems)
    getExecutionTaskItems({ getState, setState }: StateContext<ExecutionTaskItemStateModel>) {
        return this.executionTaskItemsService.getExecutionTaskItems().pipe(tap((data) => {
            const state = getState();
            setState({
                ...state,
                executionTaskItems: data.result,
            });
        }));
    }

    @Action(AddExecutionTaskItem)
    addExecutionTaskItem({ getState, setState }: StateContext<ExecutionTaskItemStateModel>, { payload }: AddExecutionTaskItem) {
        const state = getState();
        let todos = state.executionTaskItems;
        todos.push(payload);
        setState({
            ...state, executionTaskItems: todos
        });
    }
}