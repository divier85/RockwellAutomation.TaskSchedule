import { Component, Inject, OnInit } from "@angular/core";
import { Select, Store } from "@ngxs/store";
import { DOCUMENT } from "@angular/common";
import { ExecutionTaskItemState } from "../../states/executionTaskItem.state";
import { Observable } from "rxjs";
import { ExecutionTaskItem } from "../../models/executionTaskItem.model";
import { GetExecutionTaskItems } from "../../actions/executionTaskItem.action";


@Component({
    selector: 'execution-task-items-list',
    templateUrl: './executiontaskItems.component.html',
    styleUrl: './executiontaskItems.component.css'
})
export class ExecutionTaskItemsComponent implements OnInit {
    @Select(ExecutionTaskItemState.getExecutionTaskItemList) executionTaskItems: Observable<ExecutionTaskItem[]>;

    constructor(@Inject(DOCUMENT) private document: Document,
        private store: Store) {

    }

    ngOnInit() {
        this.store.dispatch(new GetExecutionTaskItems());
    }

}