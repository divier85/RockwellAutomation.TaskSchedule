export interface TaskItem {
    id: number;
    cronExpression: string;
    webUrl: string;
    dateAdded: Date;
    isActive: boolean;
}