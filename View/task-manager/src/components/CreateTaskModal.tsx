import { Grid, Button, Modal, TextField, Typography } from "@mui/material"
import { useState } from "react"
import { createTask } from "../Services/TaskService";

const style = {
    position: 'absolute' as 'absolute',
    top: '50%',
    left: '50%',
    transform: 'translate(-50%, -50%)',
    width: 400,
    bgcolor: 'background.paper',
    border: '1px solid #000',
    borderRadius: 5,
    boxShadow: 24,
    p: 4
  };

  interface Task {
    title: string,
    description: string,
    deadline: string
  }

const CreateTaskModal = () => {
    const [open, setOpen] = useState(false);
    const handleOpen = () => setOpen(true);
    const handleClose = () => setOpen(false);

    const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault();

        const { title, description, deadline } = e.target as typeof e.target & {
            title: {value: string};
            description: {value: string};
            deadline: {value: string};
        };

        const taskData: Task = {
            title: title.value,
            description: description.value,
            deadline: deadline.value
        };

        try {
            await createTask(taskData);
            alert("Task created!");
        } catch (error) {
            console.log(error);
            alert("Something went wrong, try again.")
        }
    };

    return (
        <div>
            <Button variant="outlined" color="inherit" onClick={handleOpen}>Create task</Button>

            <Modal open={open} onClose={handleClose}>
                <Grid container direction="column" sx={style}>
                    <Typography variant="h4" sx={{ color: "black" }}>Create task</Typography>
                    <form onSubmit={handleSubmit}>
                        <TextField
                            variant="filled"
                            label="Task title"
                            name="title"
                            margin="normal"
                            fullWidth
                            helperText="Title of the task"
                        />
                        <TextField
                            variant="filled"
                            label="Description"
                            name="description"
                            multiline rows={4}
                            margin="normal"
                            fullWidth
                            helperText="The description"
                        />
                        <TextField
                            variant="filled"
                            label="Deadline"
                            name="deadline"
                            margin="normal"
                            fullWidth
                            helperText="(YYYY-DD-MM)"
                        />
                        <Button variant="contained" type="submit">Create</Button>
                    </form>
                </Grid>
            </Modal>
        </div>
    )
}

export default CreateTaskModal