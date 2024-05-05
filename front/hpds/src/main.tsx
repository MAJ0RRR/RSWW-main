import React from "react";
import ReactDOM from "react-dom/client";
import "bootstrap/dist/css/bootstrap.css";
import { createBrowserRouter, RouterProvider } from "react-router-dom";
import HomePage from "./pages/HomePage";
import LogInPage from "./pages/LogInPage";
import MyTripsPage from "./pages/MyTripsPage";
import PaymentPage from "./pages/PaymentPage";
import ReservationPage from "./pages/ReservationPage";
import ResultDetailPage from "./pages/ResultDetailPage";
import SearchResultPage from "./pages/SearchResultPage";

const router = createBrowserRouter([
  {
    path: "/home",
    element: <HomePage />,
    errorElement: <div>404 Not Found</div>,
  },
  {
    path: "/login",
    element: <LogInPage />,
    errorElement: <div>404 Not Found</div>,
  },
  {
    path: "/mytrips",
    element: <MyTripsPage />,
    errorElement: <div>404 Not Found</div>,
  },
  {
    path: "/payment",
    element: <PaymentPage />,
    errorElement: <div>404 Not Found</div>,
  },
  {
    path: "/reservation",
    element: <ReservationPage />,
    errorElement: <div>404 Not Found</div>,
  },
  {
    path: "/resultdetail",
    element: <ResultDetailPage />,
    errorElement: <div>404 Not Found</div>,
  },
  {
    path: "/searchresult",
    element: <SearchResultPage />,
    errorElement: <div>404 Not Found</div>,
  },
]);

ReactDOM.createRoot(document.getElementById("root")!).render(
  <React.StrictMode>
    <RouterProvider router={router} />
  </React.StrictMode>
);
