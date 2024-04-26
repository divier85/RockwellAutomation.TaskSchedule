import { State, Action, StateContext, Selector } from '@ngxs/store';
import { tap } from 'rxjs/operators';
import { Injectable } from '@angular/core';
import { TaskItem } from '../models/taskItem.model';
import { TaskItemsService } from '../services/taskItems.service';
import { AddTaskItem, GetTaskItems, UpdateTaskItem } from '../actions/taskItem.action';

export class TaskItemStateModel {
    taskItems: TaskItem[];
    selectedTaskItem: TaskItem;
}
@Injectable()
@State<TaskItemStateModel>({
    name: 'taskItems',
    defaults: {
        taskItems: [],
        selectedTaskItem: { cronExpression: '', isActive: true, webUrl: '', id: 0, dateAdded: new Date() }
    }
})
export class TaskItemState {

    constructor(private taskItemsService: TaskItemsService) {
    }

    @Selector()
    static getTaskItemList(state: TaskItemStateModel) {
        return state.taskItems;
    }

    @Selector()
    static getSelectedTaskItem(state: TaskItemStateModel) {
        return state.selectedTaskItem;
    }

    @Action(GetTaskItems)
    getTaskItems({ getState, setState }: StateContext<TaskItemStateModel>) {
        return this.taskItemsService.getTaskItems().pipe(tap((data) => {
            const state = getState();
            setState({
                ...state,
                taskItems: data.result,
            });
        }));
    }


    @Action(AddTaskItem)
    addTaskItem({getState, patchState}: StateContext<TaskItemStateModel>, {payload}: AddTaskItem) {
        return this.taskItemsService.postTaskItem(payload).pipe(tap((result) => {
            const state = getState();
            patchState({
                taskItems: [...state.taskItems, result]
            });
        }));
    }
}