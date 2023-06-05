import { Paper, Typography, Box } from "@mui/material";
import TaskCard from "../components/TaskCard";
import CreateTaskModal from "../components/CreateTaskModal";

const Home = () => {
  return (
    <Box>
      <Typography variant="h2" sx={{ mb: "3rem" }}>
        Task overview
      </Typography>
      <Box sx={{ mb: "3rem" }}>
        <CreateTaskModal />
      </Box>
      <Paper sx={{ p: "2rem" }}>
        <Typography variant="h3" sx={{ fontWeight: "bold", mb: "2rem", textAlign: "start" }}>TODO:</Typography>
        <TaskCard />
      </Paper>
    </Box>
  );
};

export default Home;
