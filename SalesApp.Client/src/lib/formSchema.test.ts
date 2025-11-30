import { describe, expect, test } from "vitest";
import { clientSchema, employeeSchema } from "./formSchema";

describe("clientSchema", () => {
    test("pass with valid form", () => {
        const result = clientSchema.safeParse({
            code: 'C001',
            name: 'Joaquin Chumacero',
            documentNumber: 123456,
            documentTypeId: 1,
            email: 'joaquin.chumacero@gmail.com',
        });

        expect(result.success).toBe(true);
    });

    test("fails with empty form", () => {
        const result = clientSchema.safeParse({
            code: null,
            name: null,
            documentNumber: null,
            documentTypeId: null,
            email: null,
        });

        expect(result.success).toBe(false);
    });

    test("fails with invalid email", () => {
        const result = clientSchema.safeParse({
            code: 'C001',
            name: 'Joaquin Chumacero',
            documentNumber: 123456,
            documentTypeId: 1,
            email: 'invalid-email',
        });

        expect(result.success).toBe(false);
    });
});

describe("employeeSchema", () => {
    test("pass with valid form", () => {
        const result = employeeSchema.safeParse({
            code: 'E001',
            name: 'Saturnino Mamani',
            documentNumber: 9876543,
            documentTypeId: 1,
            email: 'saturnino.mamani@gmail.com',
            salary: 10000,
            role: 'Administrator',
        });

        expect(result.success).toBe(true);
    });

    test("fails with empty form", () => {
        const result = employeeSchema.safeParse({
            code: null,
            name: null,
            documentNumber: null,
            documentTypeId: null,
            email: null,
            salary: null,
            role: null,
        });

        expect(result.success).toBe(false);
    });

    test("fails with invalid email", () => {
        const result = employeeSchema.safeParse({
            code: 'E001',
            name: 'Saturnino Mamani',
            documentNumber: 9876543,
            documentTypeId: 1,
            salary: 10000,
            role: 'Administrator',
            email: 'invalid-email',
        });

        expect(result.success).toBe(false);
    });
});
