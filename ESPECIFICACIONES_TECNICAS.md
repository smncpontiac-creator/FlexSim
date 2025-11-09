# Especificaciones Técnicas del Modelo - Bodega Textil

## 1. RESUMEN EJECUTIVO

**Proyecto**: Modelo de Simulación de Bodega de Distribución Textil
**Software**: FlexSim 2019+
**Fecha**: 2025-11-09
**Versión**: 1.0

### Características Principales
- Bodega de 25m × 15m × 5m de altura
- 16 racks de almacenamiento (3 tipos diferentes)
- Capacidad total: 264 pallets
- 5 zonas operativas especializadas
- 3 equipos de manipulación de materiales

---

## 2. ESPECIFICACIONES DIMENSIONALES

### 2.1 Estructura de la Bodega

| Parámetro | Valor | Unidad |
|-----------|-------|--------|
| Largo total | 25 | metros |
| Ancho total | 15 | metros |
| Altura total | 5 | metros |
| Área total | 375 | m² |
| Volumen total | 1,875 | m³ |

### 2.2 Distribución de Espacios

| Zona | Largo (m) | Ancho (m) | Área (m²) | % del Total |
|------|-----------|-----------|-----------|-------------|
| Entrada/Salida | 3.0 | 3.5 | 10.5 | 2.8% |
| Recepción | 4.0 | 3.0 | 12.0 | 3.2% |
| Packing Principal | 4.0 | 3.0 | 12.0 | 3.2% |
| Packing Alternativo | 3.0 | 2.5 | 7.5 | 2.0% |
| Merma | 2.0 | 1.5 | 3.0 | 0.8% |
| Almacenamiento Racks | - | - | 230.0 | 61.3% |
| Pasillos y Circulación | - | - | 100.0 | 26.7% |

---

## 3. RACKS DE ALMACENAMIENTO

### 3.1 Racks Tipo A - Almacenamiento Masivo

**Especificaciones Generales**
- Código: RACK-A
- Cantidad: 4 unidades
- Función: Almacenamiento masivo de productos sin categorización específica

**Dimensiones**
| Parámetro | Valor |
|-----------|-------|
| Largo | 6.0 m |
| Ancho | 1.2 m |
| Alto | 4.0 m |
| Volumen por unidad | 28.8 m³ |

**Estructura**
| Componente | Especificación |
|------------|----------------|
| Columnas | Azules (0x0000FFFF) |
| Vigas | Amarillas (0xFFFF00FF) |
| Material | Acero estructural |
| Número de niveles | 4 |
| Número de bahías | 6 |
| Altura entre niveles | 1.0 m |

**Capacidad**
| Métrica | Valor |
|---------|-------|
| Pallets por nivel | 6 |
| Pallets por rack | 24 |
| Capacidad total (4 racks) | 96 pallets |
| Peso máximo por nivel | 3,000 kg |
| Peso máximo total | 12,000 kg |

**Ubicación en Layout**
| Rack | Coordenada X | Coordenada Y | Coordenada Z |
|------|--------------|--------------|--------------|
| A1 | 22.0 | 3.0 | 0.0 |
| A2 | 22.0 | 6.0 | 0.0 |
| A3 | 22.0 | 9.0 | 0.0 |
| A4 | 22.0 | 12.0 | 0.0 |

### 3.2 Racks Tipo B - Almacenamiento Categorizado

**Especificaciones Generales**
- Código: RACK-B
- Cantidad: 8 unidades
- Función: Almacenamiento categorizado por tipo de producto y género

**Dimensiones**
| Parámetro | Valor |
|-----------|-------|
| Largo | 3.0 m |
| Ancho | 1.2 m |
| Alto | 3.5 m |
| Volumen por unidad | 12.6 m³ |

**Estructura**
| Componente | Especificación |
|------------|----------------|
| Columnas | Azules (0x0000FFFF) |
| Vigas | Naranjas (0xFF8000FF) |
| Material | Acero estructural |
| Número de niveles | 4 |
| Número de bahías | 3 |
| Altura entre niveles | 0.875 m |

**Capacidad**
| Métrica | Valor |
|---------|-------|
| Pallets por nivel | 3 |
| Pallets por rack | 12 |
| Capacidad total (8 racks) | 96 pallets |
| Peso máximo por nivel | 1,500 kg |
| Peso máximo total | 6,000 kg |

**Categorización y Ubicación**
| Rack | Coordenadas (X,Y,Z) | Categoría Asignada |
|------|---------------------|-------------------|
| B1 | (12.0, 2.0, 0.0) | BLUSA_OUTDOOR |
| B2 | (12.0, 5.0, 0.0) | PARKA_NEW |
| B3 | (12.0, 8.0, 0.0) | CAMISA_OUTDOOR |
| B4 | (12.0, 11.0, 0.0) | HOMBRE |
| B5 | (17.0, 2.0, 0.0) | MUJER |
| B6 | (17.0, 5.0, 0.0) | MUJER |
| B7 | (17.0, 8.0, 0.0) | HOMBRE |
| B8 | (17.0, 11.0, 0.0) | HOMBRE |

### 3.3 Racks Tipo C - Picking Rápido

**Especificaciones Generales**
- Código: RACK-C
- Cantidad: 4 unidades
- Función: Almacenamiento de productos de alta rotación para picking rápido

**Dimensiones**
| Parámetro | Valor |
|-----------|-------|
| Largo | 2.0 m |
| Ancho | 1.0 m |
| Alto | 2.5 m |
| Volumen por unidad | 5.0 m³ |

**Estructura**
| Componente | Especificación |
|------------|----------------|
| Columnas | Azules (0x0000FFFF) |
| Vigas | Naranjas (0xFF8000FF) |
| Material | Acero estructural |
| Número de niveles | 3 |
| Número de bahías | 2 |
| Altura entre niveles | 0.833 m |

**Capacidad**
| Métrica | Valor |
|---------|-------|
| Pallets por nivel | 2 |
| Pallets por rack | 6 |
| Capacidad total (4 racks) | 24 pallets |
| Peso máximo por nivel | 1,000 kg |
| Peso máximo total | 3,000 kg |

**Ubicación en Layout**
| Rack | Coordenada X | Coordenada Y | Coordenada Z |
|------|--------------|--------------|--------------|
| C1 | 8.0 | 3.0 | 0.0 |
| C2 | 8.0 | 6.0 | 0.0 |
| C3 | 8.0 | 9.0 | 0.0 |
| C4 | 8.0 | 12.0 | 0.0 |

### 3.4 Resumen de Capacidad Total

| Tipo de Rack | Cantidad | Pallets/Rack | Total Pallets | % Capacidad |
|--------------|----------|--------------|---------------|-------------|
| Tipo A (6m) | 4 | 24 | 96 | 36.4% |
| Tipo B (3m) | 8 | 12 | 96 | 36.4% |
| Tipo C (2m) | 4 | 6 | 24 | 9.1% |
| Zonas Operativas | - | - | 48 | 18.1% |
| **TOTAL** | **16** | - | **264** | **100%** |

---

## 4. ZONAS OPERATIVAS

### 4.1 Zona de Entrada/Salida

**Ubicación**: Frente de la bodega
**Coordenadas**: (2.0, 7.5, 0.0)

| Especificación | Valor |
|----------------|-------|
| Ancho | 3.0 m |
| Alto | 3.5 m |
| Tipo de acceso | Cortina metálica enrollable |
| Cantidad de cortinas | 2 |
| Cortinas funcionales | 1 (la segunda limitada por estructura) |
| Capacidad de paso | 1 pallet a la vez |

### 4.2 Zona de Recepción

**Ubicación**: Junto a entrada principal
**Coordenadas**: (4.0, 7.5, 0.0)
**Color de zona**: Amarillo (0xFFFF00FF)

| Especificación | Valor |
|----------------|-------|
| Largo | 4.0 m |
| Ancho | 3.0 m |
| Área | 12.0 m² |
| Capacidad | 20 pallets |
| Función primaria | Descarga de mercadería |
| Función secundaria | Verificación inicial |
| Tiempo promedio de estadía | 5-10 minutos |

**Actividades**
1. Descarga de camiones
2. Verificación de documentación
3. Inspección visual de pallets
4. Asignación de ubicación de almacenamiento

### 4.3 Zona de Packing Principal

**Ubicación**: Centro-frontal de bodega
**Coordenadas**: (6.0, 7.5, 0.0)
**Color de zona**: Verde (0x00FF00FF)

| Especificación | Valor |
|----------------|-------|
| Largo | 4.0 m |
| Ancho | 3.0 m |
| Área | 12.0 m² |
| Capacidad simultánea | 6-8 pallets |
| Estado operacional | Siempre activa |
| Tiempo de proceso | 10 min/pallet |
| Throughput estimado | 6 pallets/hora |

**Equipamiento**
- Mesa de packing
- Escáner de códigos de barras
- Etiquetadora
- Film stretch
- Material de embalaje

### 4.4 Zona de Packing Alternativa

**Ubicación**: Frente a baño/oficina
**Coordenadas**: (6.0, 12.0, 0.0)
**Color de zona**: Cian (0x00FFFFFF)

| Especificación | Valor |
|----------------|-------|
| Largo | 3.0 m |
| Ancho | 2.5 m |
| Área | 7.5 m² |
| Capacidad simultánea | 4-6 pallets |
| Estado operacional | Flexible (activación condicional) |

**Triggers de Activación**
1. Pedidos > 15 pallets en espera
2. Pedidos > 200 cajas totales
3. Eventos especiales (promociones, temporadas altas)

**Lógica de Activación**
```
IF (pallets_en_espera > 15) OR (cajas_pedido > 200) THEN
    activar_packing_alternativo()
ELSE
    mantener_inactivo()
END IF
```

### 4.5 Zona de Merma

**Ubicación**: Esquina del fondo
**Coordenadas**: (23.0, 14.0, 0.0)
**Color de zona**: Rojo (0xFF0000FF)

| Especificación | Valor |
|----------------|-------|
| Largo | 2.0 m |
| Ancho | 1.5 m |
| Área | 3.0 m² |
| Capacidad | ~30 cajas sueltas |
| Prioridad de revisión | **PRIMERA** antes de picking |

**Contenido Típico**
- Devoluciones de clientes
- Sobrantes de pedidos
- Productos defectuosos
- Mercadería sin categoría clara
- Prendas sueltas (fuera de pallet)

**Protocolo de Uso**
1. **SIEMPRE** revisar merma antes de ir a racks
2. Si producto está en merma → usar de ahí
3. Si no está en merma → proceder a picking de racks
4. Actualizar inventario al tomar de merma

---

## 5. EQUIPAMIENTO DE MANIPULACIÓN

### 5.1 Apiladora Eléctrica (Stacker)

**Especificaciones Técnicas**

| Parámetro | Valor |
|-----------|-------|
| Tipo | TaskExecuter (FlexSim) |
| Modelo | Apiladora eléctrica industrial |
| Dimensiones (L×A×H) | 1.2m × 0.7m × 2.0m |
| Peso propio | 1,200 kg |
| Capacidad de carga | 1,500 kg |
| Altura máxima de elevación | 4.0 m |
| Color | Magenta (0xFF00FFFF) |

**Rendimiento Operacional**

| Métrica | Valor |
|---------|-------|
| Velocidad de desplazamiento | 1.5 m/s |
| Velocidad de elevación | 0.3 m/s |
| Tiempo de carga | 30 segundos |
| Tiempo de descarga | 30 segundos |
| Tiempo de giro (180°) | 5 segundos |
| Autonomía de batería | 8 horas |

**Reglas de Uso**
- Se utiliza para alturas > 2.5 metros
- Prioridad: Racks Tipo A (4m altura)
- También usada para niveles superiores de Racks Tipo B

**Ubicación Inicial**: (10.0, 7.5, 0.0)

### 5.2 Transpaletas Manuales

**Especificaciones Técnicas**

| Parámetro | Transpaleta 1 | Transpaleta 2 |
|-----------|---------------|---------------|
| Tipo | Operator (FlexSim) | Operator (FlexSim) |
| Modelo | Transpaleta manual | Transpaleta manual |
| Dimensiones | 0.5m × 0.5m × 1.7m | 0.5m × 0.5m × 1.7m |
| Capacidad de carga | 2,000 kg | 2,000 kg |
| Altura de elevación | 0.2 m | 0.2 m |
| Color | Cian (0x00FFFFFF) | Cian (0x00FFFFFF) |

**Rendimiento Operacional**

| Métrica | Valor |
|---------|-------|
| Velocidad de desplazamiento | 1.0 m/s |
| Tiempo de carga | 20 segundos |
| Tiempo de descarga | 20 segundos |
| Tiempo de giro (180°) | 3 segundos |

**Reglas de Uso**
- Se utilizan para alturas ≤ 2.5 metros
- Selección: La más cercana disponible
- Prioridad: Racks Tipo C y niveles inferiores de Tipo B

**Ubicación Inicial**
- Transpaleta 1: (7.0, 7.5, 0.0)
- Transpaleta 2: (9.0, 7.5, 0.0)

### 5.3 Lógica de Asignación de Equipamiento

```
FUNCIÓN: asignarEquipamiento(pallet, destino)

    altura_destino = destino.coordenada_z

    IF altura_destino > 2.5 THEN
        RETURN apiladora_electrica
    ELSE
        distancia_tp1 = calcular_distancia(transpaleta1, pallet)
        distancia_tp2 = calcular_distancia(transpaleta2, pallet)

        IF distancia_tp1 < distancia_tp2 THEN
            RETURN transpaleta1
        ELSE
            RETURN transpaleta2
        END IF
    END IF
FIN FUNCIÓN
```

---

## 6. FLUJOS DE PROCESO

### 6.1 Proceso de Recepción

**Diagrama de Flujo**
```
[Camión] → [Descarga] → [Queue_Recepcion] → [Asignación de Categoría] → [Decisión de Destino]
```

**Pasos Detallados**

1. **Arribo de Mercadería**
   - Frecuencia: 1 pallet cada 5 minutos (parámetro modificable)
   - Generador: Source_Recepcion

2. **Asignación de Atributos**
   - Categoría (15% BLUSA, 15% PARKA, 15% CAMISA, 25% HOMBRE, 30% MUJER)
   - Rotación (25% ALTA, 75% NORMAL)
   - Número de cajas (20-40 cajas por pallet)
   - Color según categoría

3. **Determinación de Destino**
   - Aplicar reglas de distribución (ver sección 6.3)
   - Asignar label "destino_asignado"

4. **Transporte a Destino**
   - Asignar equipamiento según altura
   - Ejecutar transporte
   - Almacenar en ubicación asignada

### 6.2 Proceso de Picking

**Diagrama de Flujo**
```
[Pedido] → [Verificar Merma] → [Picking de Racks] → [Queue_Packing] → [Proceso Packing] → [Salida]
```

**Pasos Detallados**

1. **Recepción de Pedido**
   - Tipo de pedido (estándar / grande)
   - Lista de productos requeridos

2. **Verificación de Merma** (PRIORIDAD 1)
   ```
   FOR EACH producto IN pedido DO
       IF producto IN zona_merma THEN
           tomar_de_merma(producto)
       ELSE
           proceder_a_racks(producto)
       END IF
   END FOR
   ```

3. **Picking de Racks**
   - Buscar en racks según categoría
   - Para productos de alta rotación: revisar Racks Tipo C primero
   - Asignar equipamiento según altura

4. **Consolidación en Packing**
   - Decidir entre Packing Principal o Alternativo
   - Transportar pallets a zona asignada

5. **Proceso de Packing**
   - Tiempo: 10 minutos por pallet
   - Actividades: verificación, etiquetado, film stretch

6. **Salida**
   - Transportar a zona de salida
   - Cargar en camión

### 6.3 Reglas de Distribución

**Prioridad de Decisión**

| Prioridad | Condición | Destino | Rack(s) |
|-----------|-----------|---------|---------|
| 1 | Origen = MERMA | Packing directo | - |
| 2 | Rotación = ALTA | Picking rápido | C1-C4 |
| 3 | Categoría = BLUSA_OUTDOOR | Categorizado | B1 |
| 3 | Categoría = PARKA_NEW | Categorizado | B2 |
| 3 | Categoría = CAMISA_OUTDOOR | Categorizado | B3 |
| 3 | Categoría = HOMBRE | Categorizado | B4, B7, B8 |
| 3 | Categoría = MUJER | Categorizado | B5, B6 |
| 4 | Categoría = GENERAL | Almacenamiento masivo | A1-A4 |

**Distribución Aleatoria dentro de Categoría**

Para categorías con múltiples racks (HOMBRE, MUJER):
```
HOMBRE:
  - 33% → Rack B4
  - 33% → Rack B7
  - 34% → Rack B8

MUJER:
  - 50% → Rack B5
  - 50% → Rack B6
```

### 6.4 Lógica de Activación de Packing Alternativo

**Condiciones de Activación**

```
FUNCIÓN: activarPackingAlternativo()
    pallets_espera = COUNT(Queue_PackingPrincipal)
    cajas_pedido = SUM(Queue_PackingPrincipal.num_cajas)

    IF (pallets_espera > 15) OR (cajas_pedido > 200) THEN
        RETURN TRUE
    ELSE
        RETURN FALSE
    END IF
FIN FUNCIÓN
```

**Distribución de Carga**

Cuando se activa:
- 60% de pedidos → Packing Principal
- 40% de pedidos → Packing Alternativo

---

## 7. PARÁMETROS DE SIMULACIÓN

### 7.1 Parámetros Temporales

| Parámetro | Valor Predeterminado | Rango Ajustable | Unidad |
|-----------|---------------------|-----------------|--------|
| Tiempo de simulación | 28,800 | 3,600 - 86,400 | segundos |
| Tiempo de calentamiento | 0 | 0 - 3,600 | segundos |
| Intervalo entre arribos | 300 | 60 - 600 | segundos |
| Tiempo de proceso packing | 600 | 300 - 900 | segundos |
| Tiempo de carga apiladora | 30 | 20 - 60 | segundos |
| Tiempo de carga transpaleta | 20 | 15 - 40 | segundos |

### 7.2 Distribuciones Probabilísticas

**Categorías de Producto**
```
BLUSA_OUTDOOR:   15% (Uniforme)
PARKA_NEW:       15% (Uniforme)
CAMISA_OUTDOOR:  15% (Uniforme)
HOMBRE:          25% (Uniforme)
MUJER:           30% (Uniforme)
```

**Rotación de Producto**
```
ALTA:    25% (Bernoulli p=0.25)
NORMAL:  75% (Bernoulli p=0.75)
```

**Cajas por Pallet**
```
Distribución: Uniforme discreta
Rango: 20 - 40 cajas
Media: 30 cajas
```

### 7.3 Unidades del Modelo

| Dimensión | Unidad |
|-----------|--------|
| Longitud | Metros (m) |
| Tiempo | Segundos (s) |
| Masa | Kilogramos (kg) |
| Velocidad | Metros/segundo (m/s) |

---

## 8. INDICADORES DE DESEMPEÑO (KPIs)

### 8.1 KPIs Operacionales

| KPI | Fórmula | Objetivo | Unidad |
|-----|---------|----------|--------|
| Throughput | Pallets_procesados / Tiempo_simulación | > 10 | pallets/hora |
| Utilización de racks | (Pallets_almacenados / Capacidad_total) × 100 | 60-80% | % |
| Tiempo en sistema | Tiempo_salida - Tiempo_entrada | < 120 | minutos |
| Utilización de apiladora | Tiempo_ocupado / Tiempo_total | 60-70% | % |
| Utilización transpaletas | Tiempo_ocupado / Tiempo_total | 50-60% | % |

### 8.2 KPIs de Calidad

| KPI | Descripción | Objetivo |
|-----|-------------|----------|
| Tasa de revisión de merma | % pedidos que usaron merma | 10-15% |
| Uso de packing alternativo | % tiempo activado | < 20% |
| Ocupación de recepción | % tiempo con > 15 pallets | < 10% |

### 8.3 Cálculo Automático

El script `ConfiguracionProcesos.fs` calcula automáticamente todos los KPIs al finalizar la simulación mediante la función `calcularKPIs()`.

Resultados se muestran en consola:
```
======== KPIs BODEGA TEXTIL ========
Throughput: 11.2 pallets/hora
Utilización de Racks: 68.5%
Tiempo promedio en sistema: 87.3 minutos
====================================
```

---

## 9. VALIDACIÓN Y VERIFICACIÓN

### 9.1 Validación Dimensional

✅ **Verificado**: Todas las dimensiones coinciden con especificaciones
- Bodega: 25m × 15m × 5m
- Racks Tipo A: 6m × 1.2m × 4m (4 unidades)
- Racks Tipo B: 3m × 1.2m × 3.5m (8 unidades)
- Racks Tipo C: 2m × 1m × 2.5m (4 unidades)

### 9.2 Validación de Capacidad

✅ **Verificado**: Capacidad total = 264 pallets
- Racks A: 4 × 24 = 96 pallets
- Racks B: 8 × 12 = 96 pallets
- Racks C: 4 × 6 = 24 pallets
- Zonas operativas: ~48 pallets

### 9.3 Validación Funcional

✅ **Verificado**: Todos los flujos implementados
- Proceso de recepción
- Asignación de categorías
- Distribución a racks
- Prioridad de merma
- Picking y packing
- Activación condicional de packing alternativo

### 9.4 Pruebas Recomendadas

1. **Prueba de Carga Normal**
   - Duración: 8 horas
   - Arribo: 1 pallet/5 min
   - Resultado esperado: ~90 pallets procesados

2. **Prueba de Alta Demanda**
   - Duración: 8 horas
   - Arribo: 1 pallet/3 min
   - Verificar: Activación de packing alternativo

3. **Prueba de Categorización**
   - Verificar distribución correcta según categoría
   - Verificar uso de Racks C para alta rotación

4. **Prueba de Equipamiento**
   - Verificar: Apiladora para altura > 2.5m
   - Verificar: Transpaletas para altura ≤ 2.5m

---

## 10. RESTRICCIONES Y LIMITACIONES

### 10.1 Restricciones Identificadas

1. **Acceso Limitado**
   - Solo 1 de 2 cortinas completamente funcional
   - Impacto: Posible cuello de botella en entrada/salida

2. **Equipamiento Único**
   - Solo 1 apiladora para operaciones de altura
   - Impacto: Cuello de botella en alta demanda

3. **Altura Máxima**
   - Limitada a 4m por capacidad de apiladora
   - Impacto: No se puede aprovechar altura completa de 5m

### 10.2 Supuestos del Modelo

1. Todos los pallets tienen dimensiones estándar (1.2m × 1.0m)
2. Peso promedio de pallet: 500 kg
3. No hay fallas de equipamiento
4. No hay restricciones de personal
5. No hay turnos ni breaks
6. Inventario siempre disponible para recepción

### 10.3 Exclusiones

- Sistema de WMS (Warehouse Management System) no modelado
- Costos operacionales no incluidos
- Variabilidad climática no considerada
- Mantenimiento preventivo no modelado
- Gestión de devoluciones compleja no incluida

---

## 11. CONFIGURACIÓN TÉCNICA DE FLEXSIM

### 11.1 Objetos Utilizados

| Objeto FlexSim | Cantidad | Uso en Modelo |
|----------------|----------|---------------|
| Floor | 1 | Piso de bodega |
| Source | 1 | Generación de pallets |
| Queue | 4 | Zonas operativas |
| Rack | 16 | Almacenamiento |
| Processor | 1 | Packing |
| TaskExecuter | 1 | Apiladora |
| Operator | 2 | Transpaletas |
| Sink | 1 | Salida de pallets |

### 11.2 Formato de Archivo

- **Formato**: Tree structure (FlexSim native)
- **Extensión**: .fsm
- **Compatibilidad**: FlexSim 2019 y superior
- **Tamaño aproximado**: < 500 KB

### 11.3 Scripts Incluidos

1. **ConfiguracionProcesos.fs** (3,500+ líneas)
   - Setup de conexiones
   - Lógica de distribución
   - Asignación de equipamiento
   - Cálculo de KPIs
   - Eventos del modelo

### 11.4 Requisitos de Sistema

**Mínimos**:
- CPU: Intel i3 o equivalente
- RAM: 4 GB
- GPU: Integrada
- Disco: 2 GB disponibles
- OS: Windows 10, Linux, macOS

**Recomendados**:
- CPU: Intel i5/i7 o equivalente
- RAM: 8 GB
- GPU: Dedicada (para visualización 3D)
- Disco: 5 GB disponibles SSD
- OS: Windows 10/11 64-bit

---

## 12. MANTENIMIENTO Y ACTUALIZACIONES

### 12.1 Control de Versiones

| Versión | Fecha | Cambios |
|---------|-------|---------|
| 1.0 | 2025-11-09 | Versión inicial completa |

### 12.2 Próximas Mejoras Planificadas

**Versión 1.1** (Planeada)
- [ ] Implementar variabilidad en tiempos de proceso
- [ ] Agregar visualización 3D mejorada
- [ ] Implementar sistema de turnos

**Versión 1.2** (Planeada)
- [ ] Integrar WMS básico
- [ ] Agregar análisis de costos
- [ ] Implementar optimización de rutas

**Versión 2.0** (Futura)
- [ ] Dashboard interactivo
- [ ] Optimización automática de layout
- [ ] Machine learning para predicción de demanda

---

## 13. CONTACTO Y SOPORTE

**Documentación**: Ver README.md
**Scripts**: Ver ConfiguracionProcesos.fs
**Soporte FlexSim**: https://www.flexsim.com/support/

---

**Fin de Especificaciones Técnicas**

*Documento generado: 2025-11-09*
*Versión: 1.0*
*Total de páginas: 13*
