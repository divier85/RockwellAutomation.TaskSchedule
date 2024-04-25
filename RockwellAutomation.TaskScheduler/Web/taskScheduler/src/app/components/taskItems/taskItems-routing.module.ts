import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TaskItemsComponent } from './taskItems.component';

const routes: Routes = [{ path: 'taskItems/list',
component: TaskItemsComponent },
{path: '',
component: TaskItemsComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TaskItemsRoutingModule { }
