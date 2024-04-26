import { ExecutionTaskItem } from '../models/executionTaskItem.model';

export class AddExecutionTaskItem {
    static readonly type = '[ExecutionTaskItem] Add';

    constructor(public payload: ExecutionTaskItem) {
    }
}

export class GetExecutionTaskItems {
    static readonly type = '[ExecutionTaskItem] Get';
}

export class UpdateExecutionTaskItem {
    static readonly type = '[ExecutionTaskItem] Update';

    constructor(public payload: ExecutionTaskItem, public id: number) {
    }
}

export class DeleteExecutionTaskItem {
    static readonly type = '[ExecutionTaskItem] Delete';

    constructor(public id: number) {
    }
}

export class SetSelectedExecutionTaskItem {
    static readonly type = '[ExecutionTaskItem] Set';

    constructor(public payload?: ExecutionTaskItem) {
    }
}