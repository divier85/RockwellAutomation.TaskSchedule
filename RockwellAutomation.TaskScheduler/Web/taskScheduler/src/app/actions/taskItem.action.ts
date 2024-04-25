import { TaskItem } from '../models/taskItem.model';

export class AddTaskItem {
    static readonly type = '[TaskItem] Add';

    constructor(public payload: TaskItem) {
    }
}

export class GetTaskItems {
    static readonly type = '[TaskItem] Get';
}

export class UpdateTaskItem {
    static readonly type = '[TaskItem] Update';

    constructor(public payload: TaskItem, public id: number) {
    }
}

export class DeleteTaskItem {
    static readonly type = '[TaskItem] Delete';

    constructor(public id: number) {
    }
}

export class SetSelectedTaskItem {
    static readonly type = '[TaskItem] Set';

    constructor(public payload?: TaskItem) {
    }
}