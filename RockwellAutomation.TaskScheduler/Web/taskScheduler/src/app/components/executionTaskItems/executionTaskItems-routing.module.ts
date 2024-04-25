import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ExecutionTaskItemsComponent } from './executionTaskItems.component';

const routes: Routes = [{ path: 'taskItems/execution/list',
component: ExecutionTaskItemsComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ExecutionTaskItemsRoutingModule { }
