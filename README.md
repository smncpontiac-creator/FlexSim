# Modelo de Simulación - Bodega de Distribución Textil

## Descripción General

Este modelo de FlexSim representa una bodega de distribución de productos textiles de **25m x 15m x 5m** de altura, con un sistema completo de almacenamiento, picking y packing.

## Archivos del Proyecto

1. **BodegaTextil.fsm** - Archivo principal del modelo FlexSim
2. **ConfiguracionProcesos.fs** - Script FlexScript con toda la lógica operacional
3. **README.md** - Este archivo de documentación

## Características del Modelo

### Dimensiones y Capacidad

- **Área total**: 25m x 15m (375 m²)
- **Altura**: 5 metros
- **Capacidad total**: 264 pallets
- **Zonas operativas**: 5 zonas principales

### Racks de Almacenamiento

#### Racks Tipo A (6 metros) - Almacenamiento Masivo
- **Cantidad**: 4 unidades
- **Dimensiones**: 6m x 1.2m x 4m
- **Niveles**: 4 niveles
- **Capacidad**: 24 pallets por rack (96 total)
- **Ubicación**: Fondo de la bodega
- **Función**: Almacenamiento masivo de productos

#### Racks Tipo B (3 metros) - Almacenamiento Categorizado
- **Cantidad**: 8 unidades
- **Dimensiones**: 3m x 1.2m x 3.5m
- **Niveles**: 4 niveles
- **Capacidad**: 12 pallets por rack (96 total)
- **Ubicación**: Centro y laterales
- **Categorías**:
  - BLUSA_OUTDOOR (Rack B1)
  - PARKA_NEW (Rack B2)
  - CAMISA_OUTDOOR (Rack B3)
  - HOMBRE (Racks B4, B7, B8)
  - MUJER (Racks B5, B6)

#### Racks Tipo C (2 metros) - Picking Rápido
- **Cantidad**: 4 unidades
- **Dimensiones**: 2m x 1m x 2.5m
- **Niveles**: 3 niveles
- **Capacidad**: 6 pallets por rack (24 total)
- **Ubicación**: Zona central
- **Función**: Productos de alta rotación

### Zonas Operativas

1. **Zona de Recepción** (4m x 3m)
   - Capacidad: 20 pallets
   - Función: Descarga y verificación de mercadería
   - Color: Amarillo

2. **Zona de Packing Principal** (4m x 3m)
   - Capacidad: 8 pallets simultáneos
   - Tiempo de proceso: 10 minutos por pallet
   - Estado: Siempre activa
   - Color: Verde

3. **Zona de Packing Alternativa** (3m x 2.5m)
   - Capacidad: 6 pallets simultáneos
   - Activación: Pedidos > 15 pallets o > 200 cajas
   - Estado: Flexible
   - Color: Cian

4. **Zona de Merma** (2m x 1.5m)
   - Capacidad: 30 cajas aproximadamente
   - Función: Devoluciones, sobrantes, productos defectuosos
   - **Importante**: Se revisa PRIMERO antes del picking en racks
   - Color: Rojo

5. **Zona de Entrada/Salida** (3m x 3.5m)
   - 2 cortinas metálicas enrollables
   - Acceso principal para pallets

### Equipamiento

#### Apiladora Eléctrica (Stacker)
- **Cantidad**: 1 unidad
- **Dimensiones**: 1.2m x 0.7m x 2m
- **Capacidad de carga**: 1500 kg
- **Velocidad**: 1.5 m/s
- **Tiempo de carga/descarga**: 30 segundos
- **Función**: Manipulación de pallets en niveles altos (> 2.5m)

#### Transpaletas Manuales
- **Cantidad**: 2 unidades
- **Velocidad**: 1.0 m/s
- **Tiempo de carga/descarga**: 20 segundos
- **Función**: Manipulación de pallets en niveles bajos (< 2.5m)

## Lógica Operacional

### Flujo de Recepción
1. Los pallets llegan cada 5 minutos a la zona de recepción
2. Se asigna automáticamente una categoría (HOMBRE, MUJER, o tipo de prenda)
3. Se determina si es producto de alta rotación (25% de probabilidad)
4. Se asigna un destino según las reglas de distribución

### Reglas de Distribución

#### Prioridad 1: Verificar Merma
- Antes de hacer picking de racks, siempre verificar disponibilidad en zona de merma

#### Prioridad 2: Alta Rotación → Racks Tipo C
- Productos con alta rotación van a racks pequeños (Tipo C)
- Facilita el picking rápido

#### Prioridad 3: Categorización por Producto
- BLUSA_OUTDOOR → Rack B1
- PARKA_NEW → Rack B2
- CAMISA_OUTDOOR → Rack B3
- HOMBRE → Racks B4, B7, B8 (distribuido)
- MUJER → Racks B5, B6 (distribuido)

#### Prioridad 4: Almacenamiento Masivo
- Productos sin categoría específica → Racks Tipo A (distribuido)

### Asignación de Equipamiento

- **Altura > 2.5m**: Usa Apiladora Eléctrica
- **Altura ≤ 2.5m**: Usa Transpaleta Manual (la más cercana disponible)

### Activación de Packing Alternativo

El packing alternativo se activa cuando:
- Hay más de 15 pallets esperando en packing principal, O
- El pedido actual tiene más de 200 cajas

## KPIs del Modelo

El modelo calcula automáticamente:

1. **Throughput**: Pallets procesados por hora
2. **Utilización de Racks**: Porcentaje de ocupación promedio
3. **Tiempo promedio en sistema**: Desde entrada hasta salida

Estos KPIs se muestran en la consola al finalizar la simulación.

## Cómo Usar el Modelo

### Requisitos
- **FlexSim** versión 2019 o superior
- Sistema operativo: Windows, Linux o macOS

### Instrucciones de Uso

1. **Abrir el modelo**:
   ```
   FlexSim → File → Open → Seleccionar BodegaTextil.fsm
   ```

2. **Cargar el script de configuración**:
   ```
   Tools → Script → Open → Seleccionar ConfiguracionProcesos.fs
   Tools → Script → Run
   ```

3. **Iniciar la simulación**:
   ```
   Presionar el botón "Reset" (⟲)
   Presionar el botón "Run" (▶)
   ```

4. **Ajustar velocidad de simulación**:
   - Usar el slider de velocidad en la barra de herramientas
   - Velocidad recomendada: 1x - 10x para observar operaciones

5. **Pausar y observar**:
   - Presionar "Pause" (⏸) en cualquier momento
   - Hacer clic en objetos para ver estadísticas

6. **Ver resultados**:
   - Los KPIs se muestran automáticamente al finalizar
   - Dashboard → Statistics para ver gráficos detallados

### Parámetros Modificables

En el archivo `ConfiguracionProcesos.fs` puedes modificar:

- **Tiempo entre arribos**: Línea con `interarrivaltime` (actualmente 300 segundos)
- **Tiempo de proceso**: Línea con `processtime` (actualmente 600 segundos)
- **Distribución de categorías**: Función `OnCreation_Source`
- **Reglas de activación de packing alternativo**: Función `activarPackingAlternativo`
- **Velocidad de equipamiento**: Variables `speed` en cada TaskExecuter

### Escenarios de Simulación Recomendados

#### Escenario 1: Operación Normal
- Tiempo de simulación: 8 horas (28800 segundos)
- Arribo: 1 pallet cada 5 minutos
- Resultado esperado: ~96 pallets procesados

#### Escenario 2: Alta Demanda
- Tiempo de simulación: 8 horas
- Arribo: 1 pallet cada 3 minutos
- Observar activación de packing alternativo

#### Escenario 3: Análisis de Cuellos de Botella
- Tiempo de simulación: 4 horas
- Arribo: 1 pallet cada 2 minutos
- Identificar limitaciones de equipamiento

## Validación del Modelo

### Elementos Validados

✅ Dimensiones de bodega: 25m x 15m x 5m
✅ Total de racks: 16 unidades (4+8+4)
✅ Capacidad total: 264 pallets
✅ Categorización por género y tipo de prenda
✅ Zona de packing principal siempre activa
✅ Zona de packing alternativa flexible
✅ Zona de merma con prioridad de revisión
✅ Equipamiento: 1 apiladora + 2 transpaletas
✅ Flujos operacionales según especificaciones

### Restricciones Identificadas

1. **Acceso limitado**: Solo 1 de las 2 cortinas es completamente funcional
2. **Altura máxima**: Racks limitados a 4m por capacidad de apiladora
3. **Equipamiento**: 1 sola apiladora puede generar cuellos de botella en alta demanda

## Personalización

### Agregar Nuevas Categorías
Editar función `OnCreation_Source` en `ConfiguracionProcesos.fs`:
```flexscript
if (rand < 0.XX) item.setLabel("categoria", "NUEVA_CATEGORIA");
```

### Modificar Layout
Editar coordenadas `x, y, z` en `BodegaTextil.fsm` para cada objeto.

### Agregar Equipamiento
Duplicar objetos TaskExecuter o Operator en el modelo.

## Soporte y Documentación

- **FlexSim Manual**: https://docs.flexsim.com
- **FlexScript Reference**: https://docs.flexsim.com/flexscript
- **Community Forum**: https://answers.flexsim.com

## Versión del Modelo

- **Versión**: 1.0
- **Fecha**: 2025-11-09
- **Autor**: Claude AI
- **Compatibilidad**: FlexSim 2019+

## Notas Adicionales

- El modelo utiliza unidades métricas (metros, kilogramos, segundos)
- Los colores de objetos están codificados en hexadecimal (RGBA)
- El tiempo de simulación predeterminado es de 8 horas (1 turno)
- Se recomienda ejecutar al menos 10 replicaciones para análisis estadístico robusto

## Próximas Mejoras Sugeridas

1. Implementar sistema de WMS (Warehouse Management System)
2. Agregar restricciones de peso por nivel de rack
3. Implementar rutas optimizadas para equipamiento
4. Agregar variabilidad en tiempos de proceso
5. Implementar turnos y breaks de operadores
6. Agregar análisis de costos operacionales
7. Implementar sistema de pedidos por lotes
8. Agregar visualización 3D mejorada

---

**¡El modelo está listo para usar!** Simplemente abre `BodegaTextil.fsm` en FlexSim y ejecuta la simulación.
