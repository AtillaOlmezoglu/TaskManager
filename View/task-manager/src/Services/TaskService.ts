import axios from 'axios';

export async function getAllTasks() {
    try {
        const respons = await axios.get('https://localhost:7258/api/Tasks/Get-all-tasks');
        return respons.data;
    } catch (error) {
        console.log(error);
        return [];
    }
}
