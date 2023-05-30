import Home from "./pages/Home";
import CreateTask from "./pages/CreateTask";

import {FC} from "react";

interface Route {
    key: string,
    title: string,
    path: string,
    enabled: boolean,
    component: FC<object>
}

export const routes: Array<Route> = [
  {
    key: "home-route",
    title: "Home",
    path: "/",
    enabled: true,
    component: Home,
  },
  {
    key: "createTask-route",
    title: "Create Task",
    path: "/createTask",
    enabled: true,
    component: CreateTask,
  },
];