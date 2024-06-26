﻿using MediatR;
using RockwellAutomation.TaskScheduler.Model.ExecutionTaskItem.Command.Post;

namespace RockwellAutomation.TaskScheduler.Service.ExecutionTaskItem.Command.Post
{
    public class PostExecutionTaskItemCommand : IRequest<ExecutionTaskItemModel>
    {
        public int TaskItemId { get; set; }
    }
}