import { useEffect, useState } from "react";
import { fetchEmployees } from "../lib/api.ts";
import {
  Button,
  Dialog,
  DialogContent,
  DialogTitle,
  Stack,
  Typography,
} from "@mui/material";
import { PlusIcon } from "@phosphor-icons/react";
import type { Employee } from "../types/Employee.ts";
import { EmployeeTable } from "../components/EmployeeTable.tsx";
import { EmployeeForm } from "../components/EmployeeForm.tsx";

export function EmployeePage() {
  const [open, setOpen] = useState(false);
  const [loading, setLoading] = useState(true);
  const [employees, setEmployees] = useState<Employee[]>([]);

  useEffect(() => {
    getEmployees();
  }, []);

  const getEmployees = () => {
    fetchEmployees()
      .then(setEmployees)
      .catch(() => setEmployees([]))
      .finally(() => setLoading(false));
  };

  const handleClickOpen = () => {
    setOpen(true);
  };

  const handleClose = () => {
    setOpen(false);
    getEmployees();
  };

  return (
    <Stack spacing={3}>
      <Stack direction="row" spacing={3}>
        <Stack spacing={1} sx={{ flex: "1 1 auto" }}>
          <Typography variant="h4">Empleados</Typography>
        </Stack>
        <div>
          <Button
            startIcon={<PlusIcon fontSize="var(--icon-fontSize-md)" />}
            variant="contained"
            onClick={handleClickOpen}
            id="employeeFormButton"
          >
            Registrar empleado 5
          </Button>
        </div>
      </Stack>
      <EmployeeTable employees={employees} />
      <Dialog open={open}>
        <DialogTitle>Registrar empleado</DialogTitle>
        <DialogContent>
          <EmployeeForm onClose={handleClose} />
        </DialogContent>
      </Dialog>
    </Stack>
  );
}
