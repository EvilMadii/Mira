import { v4 } from 'uuid';
enum TaskStatusEnum {
    NOT_STARTED,
    IN_PROGRESS,
    DELAYED,
    CANCELLED,
    COMPLETED
}

export class Task {
    Task_ID: string;
    Task_Name: string;
    Task_Description: string;
    Task_Status: TaskStatusEnum;
    Task_Start: Date;
    Task_End: Date;
    PROJECT_ID: string;
    constructor(_taskName: string, _taskDesc: string, _taskStart: Date, _taskEnd: Date, _projectID: string) {
        let uuid = v4();
        this.Task_ID = uuid;
        this.Task_Name = _taskName;
        this.Task_Description = _taskDesc;
        this.Task_Status = TaskStatusEnum.NOT_STARTED;
        this.Task_Start = _taskStart;
        this.Task_End = _taskEnd;
        this.PROJECT_ID = _projectID;
    }

}

