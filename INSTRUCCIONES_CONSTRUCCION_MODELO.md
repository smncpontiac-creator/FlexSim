# Construcción del Modelo de Bodega Textil en FlexSim 25.2.0

## Solución al Problema de Compatibilidad

El archivo .fsm generado tiene problemas de compatibilidad con FlexSim 25.2.0.
**SOLUCIÓN**: Construir el modelo directamente en FlexSim usando estas instrucciones paso a paso.

---

## PASO 1: Crear Nuevo Modelo

1. Abre **FlexSim 25.2.0**
2. Ve a: `File → New Model`
3. Guarda inmediatamente como: `BodegaTextil_v25.fsm`

---

## PASO 2: Configurar el Modelo

### 2.1 Configuración Básica

1. Ve a: `Model → Model Settings`
2. Configura:
   - **Units**: Metric (metros)
   - **Time Units**: Seconds
   - **Stop Time**: 28800 (8 horas)

### 2.2 Crear el Piso

1. En la **Library** busca `Floor`
2. Arrástralo a la vista 3D
3. Haz clic derecho en el Floor → `Properties`
4. Configura:
   - **Name**: `Floor_Bodega`
   - **Size X**: 25 metros
   - **Size Y**: 15 metros
   - **Position X**: 12.5
   - **Position Y**: 7.5
   - **Position Z**: 0

---

## PASO 3: Zona de Entrada y Recepción

### 3.1 Source (Entrada de Pallets)

1. Busca `Source` en Library
2. Arrástralo a la posición (2, 7.5, 0)
3. Propiedades:
   - **Name**: `Source_Recepcion`
   - **Inter-Arrival Time**: 300 segundos
   - **Item Type**: Pallet

### 3.2 Queue de Recepción

1. Busca `Queue` en Library
2. Arrástralo a la posición (4, 7.5, 0)
3. Propiedades:
   - **Name**: `Queue_Recepcion`
   - **Max Content**: 20
   - **Size X**: 4m, **Size Y**: 3m

---

## PASO 4: Crear Racks de Almacenamiento

### 4.1 Racks Tipo A (6 metros) - Fondo de Bodega

**Rack A1:**
1. Busca `Rack` en Library
2. Arrástralo a (22, 3, 0)
3. Propiedades:
   - **Name**: `Rack_A1`
   - **Size X**: 6m, **Size Y**: 1.2m, **Height**: 4m
   - **Levels**: 4
   - **Bays**: 6

**Repite para Rack A2, A3, A4:**
- **Rack_A2**: Posición (22, 6, 0)
- **Rack_A3**: Posición (22, 9, 0)
- **Rack_A4**: Posición (22, 12, 0)

### 4.2 Racks Tipo B (3 metros) - Centro

**Crea 8 racks con estas posiciones:**

| Rack  | Posición X | Posición Y | Categoría      |
|-------|------------|------------|----------------|
| B1    | 12         | 2          | BLUSA_OUTDOOR  |
| B2    | 12         | 5          | PARKA_NEW      |
| B3    | 12         | 8          | CAMISA_OUTDOOR |
| B4    | 12         | 11         | HOMBRE         |
| B5    | 17         | 2          | MUJER          |
| B6    | 17         | 5          | MUJER          |
| B7    | 17         | 8          | HOMBRE         |
| B8    | 17         | 11         | HOMBRE         |

**Configuración para todos:**
- **Size X**: 3m, **Size Y**: 1.2m, **Height**: 3.5m
- **Levels**: 4
- **Bays**: 3

### 4.3 Racks Tipo C (2 metros) - Picking Rápido

**Crea 4 racks:**

| Rack | Posición X | Posición Y |
|------|------------|------------|
| C1   | 8          | 3          |
| C2   | 8          | 6          |
| C3   | 8          | 9          |
| C4   | 8          | 12         |

**Configuración:**
- **Size X**: 2m, **Size Y**: 1m, **Height**: 2.5m
- **Levels**: 3
- **Bays**: 2

---

## PASO 5: Zonas de Packing

### 5.1 Packing Principal

1. **Queue_PackingPrincipal**:
   - Posición: (6, 7.5, 0)
   - Max Content: 8
   - Size: 4m x 3m

2. **Processor_Packing**:
   - Busca `Processor` en Library
   - Posición: (6, 7.5, 0)
   - Process Time: 600 segundos (10 minutos)

### 5.2 Packing Alternativo

1. **Queue_PackingAlternativo**:
   - Posición: (6, 12, 0)
   - Max Content: 6
   - Size: 3m x 2.5m

---

## PASO 6: Zona de Merma

1. **Queue_Merma**:
   - Posición: (23, 14, 0)
   - Max Content: 30
   - Size: 2m x 1.5m
   - **Color**: Rojo (para identificar fácilmente)

---

## PASO 7: Equipamiento

### 7.1 Apiladora Eléctrica

1. Busca `TaskExecuter` en Library
2. Posición: (10, 7.5, 0)
3. Propiedades:
   - **Name**: `Apiladora_Electrica`
   - **Speed**: 1.5 m/s
   - **Load Time**: 30 segundos
   - **Unload Time**: 30 segundos

### 7.2 Transpaletas Manuales

**Transpaleta 1:**
1. Busca `Operator` en Library
2. Posición: (7, 7.5, 0)
3. Propiedades:
   - **Name**: `Transpaleta_1`
   - **Speed**: 1.0 m/s
   - **Load Time**: 20 segundos

**Transpaleta 2:**
- Posición: (9, 7.5, 0)
- Mismas propiedades

---

## PASO 8: Zona de Salida

1. Busca `Sink` en Library
2. Posición: (2, 10, 0)
3. Propiedades:
   - **Name**: `Sink_Salida`

---

## PASO 9: Conectar el Flujo

### 9.1 Conexiones Básicas

Para conectar objetos en FlexSim 25.2.0:

1. Presiona la tecla **"A"** (Connect Mode)
2. Haz clic en el objeto de origen
3. Haz clic en el objeto de destino
4. Presiona **"Q"** para salir del modo conexión

**Conectar en este orden:**

```
Source_Recepcion → Queue_Recepcion
Queue_Recepcion → Todos los Racks (A1-A4, B1-B8, C1-C4)
Todos los Racks → Queue_PackingPrincipal
Queue_PackingPrincipal → Processor_Packing
Processor_Packing → Sink_Salida
```

---

## PASO 10: Configurar Lógica con FlexScript

### 10.1 Source - Asignar Categorías

1. Haz clic derecho en `Source_Recepcion`
2. Ve a: `Triggers → On Creation`
3. Pega este código:

```flexscript
// Asignar categoría al pallet
item.Type = duniform(1, 5); // 5 tipos diferentes

// Asignar etiquetas
if (item.Type == 1) item.label = "HOMBRE";
else if (item.Type == 2) item.label = "MUJER";
else if (item.Type == 3) item.label = "BLUSA_OUTDOOR";
else if (item.Type == 4) item.label = "PARKA_NEW";
else if (item.Type == 5) item.label = "CAMISA_OUTDOOR";

// Alta rotación (25% de probabilidad)
if (duniform(1, 4) == 1) {
    item.AltaRotacion = 1;
} else {
    item.AltaRotacion = 0;
}

return 1;
```

### 10.2 Queue_Recepcion - Enviar a Rack Correcto

1. Haz clic derecho en `Queue_Recepcion`
2. Ve a: `Triggers → Send To Port`
3. Pega este código:

```flexscript
// Si es alta rotación, enviar a Racks tipo C (picking rápido)
if (item.AltaRotacion == 1) {
    return duniform(1, 4); // Racks C1-C4 (puerto 1-4)
}

// Por categoría
string categoria = item.label;

if (categoria == "BLUSA_OUTDOOR") return 5; // Rack B1
if (categoria == "PARKA_NEW") return 6; // Rack B2
if (categoria == "CAMISA_OUTDOOR") return 7; // Rack B3
if (categoria == "HOMBRE") return duniform(8, 10); // Racks B4, B7, B8
if (categoria == "MUJER") return duniform(11, 12); // Racks B5, B6

// Por defecto, a Racks tipo A
return duniform(13, 16); // Racks A1-A4
```

---

## PASO 11: Ejecutar la Simulación

1. Presiona el botón **Reset** (⟲)
2. Presiona el botón **Run** (▶)
3. Observa el flujo de pallets
4. Ajusta la velocidad con el slider

---

## PASO 12: Verificar KPIs

1. Ve a: `View → Dashboard`
2. Agrega gráficos:
   - **Content Over Time** para ver ocupación de racks
   - **Throughput** para pallets procesados
   - **State Bar** para ver utilización de equipamiento

---

## Alternativa Rápida: Modelo Simplificado

Si los errores persisten, crea un **modelo minimalista** para probar FlexSim:

1. **File → New Model**
2. Arrastra solo estos objetos:
   - 1 **Source**
   - 1 **Queue**
   - 1 **Processor**
   - 1 **Sink**
3. Conéctalos en orden: Source → Queue → Processor → Sink
4. Presiona **Reset** y **Run**

Si este modelo simple funciona, entonces puedes ir agregando los racks y equipamiento gradualmente.

---

## Solución de Problemas

### Si FlexSim muestra errores al abrir archivos .fsm:

1. **Verifica la versión**: Asegúrate de tener FlexSim 25.2.0
2. **Permisos**: Ejecuta FlexSim como administrador
3. **Reinstala**: Si persisten errores, reinstala FlexSim
4. **Usa plantillas**: Ve a `File → New From Template` y modifica una plantilla existente

### Si necesitas el modelo completo funcional:

Usa la versión Express/Free de FlexSim 25.2.0 y construye el modelo paso a paso siguiendo esta guía. Los archivos .fsm generados manualmente pueden tener problemas de compatibilidad con la estructura interna de FlexSim.

---

## Guardar el Modelo

1. **File → Save As**
2. Nombre: `BodegaTextil_FlexSim25.fsm`
3. Guarda en la carpeta del proyecto

---

**¡Ahora tienes las instrucciones completas para construir el modelo directamente en FlexSim 25.2.0!**
