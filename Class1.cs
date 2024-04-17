// BusinessLogic.h
#pragma once
#include <vector>
#include "DataAccess.h"

class BusinessLogic
{
    public:
    double calcularDescuento(int cantidadPersonas);
    double calcularDescuentoAdicional(const std::string& tipo);
    double calcularImporte(const std::string& ruta, int cantidadPersonas, const std::string& tipo);
    double calcularImporteTotal(const std::vector<Cliente>& clientes);
};

// BusinessLogic.cpp
#include "BusinessLogic.h"
#include <cmath>

double BusinessLogic::calcularDescuento(int cantidadPersonas) {
    if (cantidadPersonas == 1) return 0.0;
    if (cantidadPersonas >= 2 && cantidadPersonas <= 7) return 0.08;
    if (cantidadPersonas >= 8 && cantidadPersonas <= 16) return 0.13;
    return 0.15;  // cantidadPersonas >= 17
}

double BusinessLogic::calcularDescuentoAdicional(const std::string& tipo) {
    if (tipo == "colegio") return 0.07;
if (tipo == "adulto_mayor") return 0.05;
return 0.0;
}

double BusinessLogic::calcularImporte(const std::string& ruta, int cantidadPersonas, const std::string& tipo) {
    double precioBase;

if (ruta == "sacsayhuaman") precioBase = 100.0;
else if (ruta == "tipon") precioBase = 120.0;
else if (ruta == "ollantaytambo") precioBase = 150.0;
else precioBase = 0.0;

double descuento = calcularDescuento(cantidadPersonas);
double descuentoAdicional = calcularDescuentoAdicional(tipo);
double importe = precioBase * cantidadPersonas * (1 - descuento) * (1 - descuentoAdicional);

return importe;
}

double BusinessLogic::calcularImporteTotal(const std::vector<Cliente>& clientes) {
    double importeTotal = 0.0;
for (const auto&cliente : clientes) {
        importeTotal += cliente.importe;
    }
    return importeTotal;
}
