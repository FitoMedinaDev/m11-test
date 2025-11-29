import { useSnackbar } from 'notistack';
import { type EmployeeFormData, employeeSchema } from '../lib/formSchema.ts';
import { Controller, useForm } from 'react-hook-form';
import { zodResolver } from '@hookform/resolvers/zod';
import { useEffect, useState } from 'react';
import type { DocumentType } from '../types/DocumentType';
import { fetchDocumentTypes, saveEmployee } from '../lib/api.ts';
import {
  Box,
  Button,
  DialogActions,
  FormControl,
  FormHelperText,
  Grid,
  InputLabel,
  MenuItem,
  Select,
  TextField
} from '@mui/material';

interface EmployeeFormProps {
  onClose: () => void
}

export function EmployeeForm({ onClose }: EmployeeFormProps): React.JSX.Element {
  const { enqueueSnackbar } = useSnackbar();

  const {
    register,
    handleSubmit,
    control,
    formState: { errors }
  } = useForm<EmployeeFormData>({
    resolver: zodResolver(employeeSchema)
  });

  const [loading, setLoading] = useState<boolean>(true);
  const [documentTypes, setDocumentTypes] = useState<DocumentType[]>();

  useEffect(() => {
    fetchDocumentTypes()
      .then(setDocumentTypes)
      .catch(() => setDocumentTypes([]))
      .finally(() => setLoading(false));
  }, []);

  const handleClose = () => {
    onClose();
  };

  const onSubmit = (data: EmployeeFormData) => {
    saveEmployee(data)
      .then(() => {
        onClose();
        enqueueSnackbar('El empleado ha sido registrado exitosamente', {
          variant: 'success'
        });
      })
      .catch(() =>
        enqueueSnackbar('Hubo un error al registrar al empleado', {
          variant: 'error'
        })
      );
  };

  return (
    <Box component="form" onSubmit={handleSubmit(onSubmit)} noValidate>
      <Grid container spacing={1}>
        <Grid size={{ xs: 12 }}>
          <TextField
            id="code"
            fullWidth
            label="Código"
            margin="dense"
            size="small"
            {...register('code')}
            error={!!errors.code}
            helperText={errors.code?.message}
          />
        </Grid>

        <Grid size={{ xs: 12 }}>
          <TextField
            id="name"
            fullWidth
            label="Nombre"
            margin="dense"
            size="small"
            {...register('name')}
            error={!!errors.name}
            helperText={errors.name?.message}
          />
        </Grid>

        <Grid size={{ xs: 12 }}>
          <TextField
            id="email"
            fullWidth
            label="Email"
            margin="dense"
            size="small"
            {...register('email')}
            error={!!errors.email}
            helperText={errors.email?.message}
          />
        </Grid>

        <Grid size={{ xs: 12, md: 6 }}>
          <FormControl
            fullWidth
            required
            margin="dense"
            size="small"
            error={!!errors.documentTypeId}
          >
            <InputLabel id="documentTypeLabel">Tipo de documento</InputLabel>
            <Controller
              control={control}
              name="documentTypeId"
              defaultValue={0}
              render={({ field }) => (
                <Select
                  id="documentType"
                  labelId="documentTypeLabel"
                  label="Tipo de documento"
                  {...field}
                  disabled={loading}
                >
                  <MenuItem value={0}>
                    <em>Seleccionar...</em>
                  </MenuItem>
                  {documentTypes?.map((dt) => (
                    <MenuItem value={dt.id}>{dt.name}</MenuItem>
                  ))}
                </Select>
              )}
            />
            <FormHelperText> {errors.documentTypeId?.message} </FormHelperText>
          </FormControl>
        </Grid>

        <Grid size={{ xs: 12, md: 6 }}>
          <TextField
            id="documentNumber"
            fullWidth
            label="Número de documento"
            margin="dense"
            size="small"
            {...register('documentNumber')}
            error={!!errors.documentNumber}
            helperText={errors.documentNumber?.message}
          />
        </Grid>

        <Grid size={{ xs: 12, md: 6 }}>
          <TextField
            id="salary"
            fullWidth
            label="Salario"
            margin="dense"
            size="small"
            {...register('salary')}
            error={!!errors.salary}
            helperText={errors.salary?.message}
          />
        </Grid>

        <Grid size={{ xs: 12, md: 6 }}>
          <TextField
            id="role"
            fullWidth
            label="Rol"
            margin="dense"
            size="small"
            {...register('role')}
            error={!!errors.role}
            helperText={errors.role?.message}
          />
        </Grid>
      </Grid>
      <DialogActions sx={{ justifyContent: 'flex-end' }}>
        <Button variant="text" onClick={handleClose}>
          {' '}
          Cerrar{' '}
        </Button>
        <Button variant="contained" type="submit" id="saveButton">
          Guardar
        </Button>
      </DialogActions>
    </Box>
  );
}
