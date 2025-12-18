import { useEffect, useState } from "react";
import { TaskForm } from "./components/TaskForm";
import { TaskList } from "./components/TaskList";
import axios from "axios";

const api = axios.create({
  baseURL: "http://localhost:5000/api"
});

function App() {
  const [tasks, setTasks] = useState([]);

  const loadTasks = async () => {
    const res = await api.get("/tasks");
    setTasks(res.data);
  };

  useEffect(() => {
    loadTasks();
  }, []);

  const handleCreateTask = async (e) => {
    e.preventDefault();

    const form = new FormData(e.target);

    await api.post("/tasks", form);
    e.target.reset();
    loadTasks();
  };

  return (
    <div className="container">
      <h1>Task Manager</h1>

      <TaskForm onSubmit={handleCreateTask} />
      <TaskList tasks={tasks} />
    </div>
  );
}

export default App;
