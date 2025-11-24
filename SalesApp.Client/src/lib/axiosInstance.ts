import axios from "axios";

const instance = axios.create({
  baseURL: `${import.meta.env.VITE_API_URL}/api/v1`, // replace with your real API URL
  timeout: 5000,
  headers: {
    "Content-Type": "application/json",
  }
});

// Optional: interceptors for auth, logging, etc.
instance.interceptors.response.use(
  (response) => response,
  (error) => {
    // You could handle global errors here (e.g., toast, redirect)
    return Promise.reject(error);
  }
);

export default instance;
