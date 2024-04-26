import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { TaskItem } from '../models/taskItem.model';
import { environment } from '../../environments/environment';

@Injectable({
    providedIn: 'root'
})
export class TaskItemsService {

    private apiURL: string;

    constructor(private http: HttpClient) {
        this.apiURL = environment.API_URL as string;
    }

    getTaskItems() {
        return this.http.get<{ result: TaskItem[] }>(`${this.apiURL}/TaskItem/get-task-items`, {
            headers: {
                'Access-Control-Allow-Origin': '*'
            }
        });
    }

    postTaskItem(payload: TaskItem) {
        return this.http.post<TaskItem>(`${this.apiURL}/TaskItem/post-task-item`, payload);
    }
}