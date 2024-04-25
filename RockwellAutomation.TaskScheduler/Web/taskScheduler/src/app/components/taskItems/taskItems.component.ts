import { Component, Inject, OnInit } from "@angular/core";
import { Select, Store } from "@ngxs/store";
import { DOCUMENT } from "@angular/common";
import { TaskItemState } from "../../states/taskItem.state";
import { Observable } from "rxjs";
import { TaskItem } from "../../models/taskItem.model";
import { GetTaskItems } from "../../actions/taskItem.action";


@Component({
    selector: 'task-items-list',
    templateUrl: './taskItems.component.html',
    styleUrl: './taskItems.component.css'
})
export class TaskItemsComponent implements OnInit {
    @Select(TaskItemState.getTaskItemList) taskItems: Observable<TaskItem[]>;

    constructor(@Inject(DOCUMENT) private document: Document,
        private store: Store) {

    }

    ngOnInit() {
        this.store.dispatch(new GetTaskItems());
    }

}