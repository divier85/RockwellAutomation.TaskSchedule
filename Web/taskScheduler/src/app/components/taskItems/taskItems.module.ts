import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { provideClientHydration } from '@angular/platform-browser';
import { NgxsModule } from '@ngxs/store';
import { NgxsReduxDevtoolsPluginModule } from '@ngxs/devtools-plugin';
import { NgxsLoggerPluginModule } from '@ngxs/logger-plugin';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { TaskItemState } from '../../states/taskItem.state';
import { TaskItemsComponent } from './taskItems.component';
import { TaskItemsRoutingModule } from './taskItems-routing.module';
import { TaskItemFormComponent } from './taskItemForm/taskItem.form.component';

@NgModule({
  declarations: [
    TaskItemsComponent,
    TaskItemFormComponent
  ],
  imports: [
    CommonModule,
    NgxsModule.forRoot([TaskItemState]),
    NgxsReduxDevtoolsPluginModule.forRoot(),
    NgxsLoggerPluginModule.forRoot(),
    HttpClientModule,
    ReactiveFormsModule,
    TaskItemsRoutingModule
  ],
  providers: [
    provideClientHydration()]
})
export class TaskItemsModule { }
