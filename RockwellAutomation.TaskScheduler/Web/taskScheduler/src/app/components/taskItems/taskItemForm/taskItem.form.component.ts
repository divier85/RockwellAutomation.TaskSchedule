import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Select, Store } from '@ngxs/store';
import { ActivatedRoute, Router } from '@angular/router';
import { AddTaskItem, SetSelectedTaskItem } from '../../../actions/taskItem.action';
import { Observable, Subscription } from 'rxjs';
import { TaskItem } from '../../../models/taskItem.model';
import { TaskItemState } from '../../../states/taskItem.state';
import cron from 'cron-validate'

@Component({
    selector: 'task-item-form',
    templateUrl: './taskItem.form.component.html',
    styleUrls: ['./taskItem.form.component.scss']
})
export class TaskItemFormComponent implements OnInit, OnDestroy {
    @Select(TaskItemState.getSelectedTaskItem) selectedTodo: Observable<TaskItem>;
    public todoForm: FormGroup;
    public urlRegex = /^(?:http(s)?:\/\/)?[\w.-]+(?:\.[\w\.-]+)+[\w\-\._~:/?#[\]@!\$&'\(\)\*\+,;=.]+$/;
    private formSubscription: Subscription = new Subscription();
 
    constructor(private fb: FormBuilder, private store: Store, private route: ActivatedRoute, private router: Router) {

        this.createForm();

    }
    ngOnDestroy(): void {

    }

    ngOnInit() {
    }

    createForm() {

        this.todoForm = this.fb.group({
            webUrl:['',[ Validators.required, Validators.pattern(this.urlRegex)]],
            cronExpression: ['', Validators.required]
        });
    }

    onSubmit() {
        if (!this.todoForm.invalid && this.isValidCronExpression(this.todoForm.value.cronExpression)) {
            var taskItem: TaskItem = {
                id: 0,
                cronExpression: this.todoForm.value.cronExpression,
                dateAdded: new Date(),
                isActive: true,
                webUrl: this.todoForm.value.webUrl
            }
            this.formSubscription.add(
                this.formSubscription = this.store.dispatch(new AddTaskItem(taskItem)).subscribe(() => {
                    this.clearForm();
                })
            );
        }
    }


    isValidCronExpression(cronExpression: string): boolean {
        const cronResult = cron(cronExpression)
        return cronResult.isValid();
    }
    clearForm() {
        this.todoForm.reset();
    }
}