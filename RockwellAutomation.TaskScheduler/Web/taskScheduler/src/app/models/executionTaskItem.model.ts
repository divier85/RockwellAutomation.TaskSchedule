export interface ExecutionTaskItem {
    id: number;
    taskItemId: number;
    webUrl: string;
    cronExpression: string;
    headers: string;
    dateAdded: Date;
}