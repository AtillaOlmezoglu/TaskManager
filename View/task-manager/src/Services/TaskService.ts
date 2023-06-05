import axios from "axios";

export async function getAllTasks() {
  try {
    const response = await axios.get(
      "https://localhost:7258/api/Tasks/Get-all-tasks"
    );
    return response.data;
  } catch (error) {
    console.log(error);
    return [];
  }
}

export async function createTask(taskData: object) {
  try {
    const response = await axios.post(`https://localhost:7258/api/Tasks/Create`, taskData);
    return response.data;
  } catch (error) {
    console.log(error);
    return error;
  }
}

export async function updateTask(
  id: number,
  title: string,
  description: string,
  dueDate: Date,
  isCompleted: boolean
) {
  try {
    const response = await axios.put(
      `https://localhost:7258/api/Tasks/Update/${id}`,
      {
        title,
        description,
        dueDate,
        isCompleted,
      }
    );
    return response.data;
  } catch (error) {
    console.log(error);
    return error;
  }
}

export async function deleteTask(id: number) {
  try {
    const response = await axios.delete(
      `https://localhost:7258/api/Tasks/Delete${id}`
    );
    return response.data;
  } catch (error) {
    console.log(error);
    return error;
  }
}
