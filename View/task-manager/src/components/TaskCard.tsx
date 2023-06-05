import { Card, CardContent, CardActions, Typography, Box, FormControlLabel, Checkbox } from "@mui/material";
import { useEffect, useState, FC, ReactElement } from "react";
import { deleteTask, getAllTasks, updateTask } from "../Services/TaskService";
import ScheduleIcon from '@mui/icons-material/Schedule';
import DeleteOutlineIcon from '@mui/icons-material/DeleteOutline';

interface Task {
    id: number,
    title: string,
    description: string,
    dueDate: Date,
    createdDate: Date,
    isCompleted: boolean
}

const TaskCard: FC = (): ReactElement => {
  const [tasks, setTasks] = useState<Task[]>([]);

  useEffect(() => {
    getAllTasks().then((response) => {
      setTasks(response);
      console.log(response);
    });
  }, []);

  const handleCheckboxToggle = async (task: Task) => {
    try {
      const updatedTask = {
        //Clone the task and toggling the boolean
        ...task,
        isCompleted: task.isCompleted ? false : true,
      };

      //Update the database with DTO properties
      await updateTask(
        updatedTask.id,
        updatedTask.title,
        updatedTask.description,
        updatedTask.dueDate,
        updatedTask.isCompleted
      );

      //Update the UI with a new updated array of tasks
      const updatedTasks = tasks.map((t) => {
        if (t.id === task.id) {
          return updatedTask;
        }
        return t;
      });

      setTasks(updatedTasks);

    } catch (error) {
      console.error(error);
    }
  };

  const handleDeleteTask = async (id: number) => {
    try {
        await deleteTask(id);

        const updateTasks = await getAllTasks();
        setTasks(updateTasks);

        alert("Task deleted!")
    } catch (error) {
        console.log(error)
        alert("Something went wrong!")
    }
  }

  const getDaysAgo = (createdDate: Date): string => {
    const today = new Date();
    const diffInTime = today.getTime() - new Date(createdDate).getTime();
    const diffInDays = Math.floor(diffInTime / (1000 * 3600 * 24));

    if (diffInDays == 1){
        return `${diffInDays} day ago`;
    } else if (diffInDays > 1) {
        return `${diffInDays} days ago`;
    } else {
        return "Today"
    }
  };

  return (
    <Box>
      {tasks.map((task) => (
        <Card sx={{ maxWidth: "400px", mt: "30px" }} elevation={20} key={task.id}>
          <CardContent sx={{ textAlign: "start", pb: "0" }}>
            <Typography variant="caption">
              {getDaysAgo(task.createdDate)}
            </Typography>
            <Typography variant="h4" sx={{ mb: "0.5rem" }}>
              {task.title}
            </Typography>
            <Typography variant="body1">{task.description}</Typography>
            <Box display="flex" flexDirection="row" sx={{ pt: "2rem" }}>
              <ScheduleIcon />
              <Typography variant="body2" sx={{ p: "2px 0 0 3px" }}>
                Due to: {task.dueDate.toString().slice(0, 10)}
              </Typography>
            </Box>
          </CardContent>
          <CardActions sx={{ display: "flex", flexDirection: "row", gap: 29 }}>
            <FormControlLabel
              value="Start"
              control={
                <Checkbox
                  checked={task.isCompleted}
                  onClick={() => handleCheckboxToggle(task)}
                />
              }
              label="Complete"
              labelPlacement="start"
            />
            <Box sx={{ cursor: "pointer" }} onClick={() => handleDeleteTask(task.id)}>
              <DeleteOutlineIcon />
            </Box>
          </CardActions>
        </Card>
      ))}
    </Box>
  );
};

export default TaskCard;
