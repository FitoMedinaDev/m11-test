import type { Employee } from '../types/Employee.ts';
import { Box, Card, Table, TableBody, TableCell, TableHead, TableRow } from '@mui/material';

interface EmployeeTableProps {
  employees: Employee[]
}

export function EmployeeTable({ employees }: EmployeeTableProps): React.JSX.Element {
  return (
    <Card>
      <Box sx={{ overflowX: 'auto' }}>
        <Table sx={{ minWidth: '800px' }}>
          <TableHead>
            <TableRow>
              <TableCell> Código </TableCell>
              <TableCell> Nombre </TableCell>
              <TableCell> Email </TableCell>
              <TableCell> Tipo de documento </TableCell>
              <TableCell> Número de documento </TableCell>
              <TableCell> Salario </TableCell>
              <TableCell> Rol </TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {
              employees.length === 0
                ? (
                  <TableRow sx={{ textAlign: 'center' }}>
                    <TableCell colSpan={7} align="center">
                      Lista de empleados vacía
                    </TableCell>
                  </TableRow>
                ) :
                null
            }
            {
              employees.map(employee => (
                <TableRow key={employee.id}>
                  <TableCell> {employee.code} </TableCell>
                  <TableCell> {employee.name} </TableCell>
                  <TableCell> {employee.email} </TableCell>
                  <TableCell> {employee.documentType.name} </TableCell>
                  <TableCell> {employee.documentNumber} </TableCell>
                  <TableCell> {employee.salary} </TableCell>
                  <TableCell> {employee.role} </TableCell>
                </TableRow>
              ))
            }
          </TableBody>
        </Table>
      </Box>
    </Card>
  )
}
