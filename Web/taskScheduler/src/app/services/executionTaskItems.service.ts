import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ExecutionTaskItem } from '../models/executionTaskItem.model';
import * as process from 'process';
import { environment } from '../../environments/environment';

@Injectable({
    providedIn: 'root'
})
export class ExecutionTaskItemsService {
    
    private apiURL: string;

    constructor(private http: HttpClient) {
        this.apiURL = environment.API_URL as string;
    }

    getExecutionTaskItems() {
        return this.http.get<{result:ExecutionTaskItem[]}>(`${this.apiURL}/TaskItem/get-execution-task-items`, {
            headers: {
                'Access-Control-Allow-Origin': '*'
            }
        });
    }
}