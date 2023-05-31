import { Paper, Grid, Typography, Box } from "@mui/material";
import TaskCard from "../components/TaskCard";

const Home = () => {
  return (
    <Box>
      <Typography variant="h2" sx={{ mb: "3rem" }}>
        Task overview
      </Typography>
      <Grid container gap={50} direction="row">
        <Grid item>
          <Paper sx={{ p: "2rem" }}>
            <Typography variant="h3" sx={{ fontWeight: "bold", mb: "2rem", textAlign: "start" }}>TODO:</Typography>
            <TaskCard />
          </Paper>
        </Grid>
        <Grid item>
          <Paper elevation={3} sx={{ p: "2rem" }}>
            <Typography variant="h3" sx={{ fontWeight: "bold", mb: "2rem", textAlign: "start" }}>DONE</Typography>
          </Paper>
        </Grid>
      </Grid>
    </Box>
  );
};

export default Home;
