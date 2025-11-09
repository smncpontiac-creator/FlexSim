# Guía de Inicio Rápido - Bodega Textil FlexSim

## ¿Qué es este proyecto?

Este es un modelo completo de simulación de una bodega de distribución textil construido en FlexSim. Simula operaciones reales de almacenamiento, picking y packing de productos textiles.

---

## 🚀 Inicio Rápido en 5 Pasos

### Paso 1: Requisitos Previos
- **FlexSim** instalado (versión 2019 o superior)
- Sistema operativo: Windows, Linux o macOS
- 4 GB RAM mínimo (8 GB recomendado)

### Paso 2: Abrir el Modelo
1. Ejecuta FlexSim
2. Ve a **File → Open**
3. Selecciona `BodegaTextil.fsm`
4. Espera a que cargue el modelo

### Paso 3: Ejecutar el Script de Configuración
1. Ve a **Tools → Script Console**
2. Click en **Open** (icono de carpeta)
3. Selecciona `ConfiguracionProcesos.fs`
4. Click en **Run** (botón play verde)
5. Deberías ver: "Modelo inicializado correctamente."

### Paso 4: Iniciar la Simulación
1. Click en el botón **Reset** (⟲) en la barra de herramientas
2. Click en el botón **Run** (▶)
3. ¡La simulación está corriendo!

### Paso 5: Observar y Analizar
- Usa el slider de velocidad para ajustar la velocidad de simulación
- Haz click en objetos para ver estadísticas en tiempo real
- Al finalizar (8 horas simuladas), verás los KPIs en la consola

---

## 📊 ¿Qué Estoy Viendo?

### Vista Principal del Modelo

Cuando abras el modelo verás:

#### Colores de las Zonas:
- **Amarillo**: Zona de Recepción
- **Verde**: Zona de Packing Principal
- **Cian**: Zona de Packing Alternativa
- **Rojo**: Zona de Merma

#### Los Racks:
- **Azul con vigas amarillas**: Racks grandes (6m) - Almacenamiento masivo
- **Azul con vigas naranjas**: Racks medianos (3m) y pequeños (2m) - Categorizado

#### Equipamiento:
- **Magenta**: Apiladora eléctrica (moviéndose entre racks altos)
- **Cian**: Transpaletas manuales (moviéndose en zona baja)
- **Cajas/Pallets**: Productos moviéndose por la bodega

---

## 🎯 Escenarios de Prueba

### Escenario 1: Operación Normal (Recomendado para empezar)

**Configuración predeterminada** - Sin cambios necesarios

**Qué observar:**
- Flujo constante de pallets desde recepción
- Almacenamiento distribuido en diferentes racks
- Packing principal siempre activo
- ~90-96 pallets procesados en 8 horas

**Resultado esperado:**
- Throughput: 11-12 pallets/hora
- Utilización de racks: 60-70%

---

### Escenario 2: Alta Demanda

**Modificar en `ConfiguracionProcesos.fs`:**

Busca la línea:
```flexscript
num interarrivaltime: 300  // Un pallet cada 5 minutos
```

Cámbiala a:
```flexscript
num interarrivaltime: 180  // Un pallet cada 3 minutos
```

**Qué observar:**
- Activación del packing alternativo
- Mayor utilización de equipamiento
- Posibles colas de espera

---

### Escenario 3: Productos de Alta Rotación

**Modificar en `ConfiguracionProcesos.fs`:**

Busca:
```flexscript
if (uniform(0, 1) < 0.25) item.setLabel("rotacion", "ALTA");
```

Cámbiala a:
```flexscript
if (uniform(0, 1) < 0.60) item.setLabel("rotacion", "ALTA");
```

**Qué observar:**
- Más uso de racks tipo C (picking rápido)
- Tiempos de picking reducidos

---

## 📈 Entendiendo los Resultados

### Al finalizar la simulación verás:

```
======== KPIs BODEGA TEXTIL ========
Throughput: 11.2 pallets/hora
Utilización de Racks: 68.5%
Tiempo promedio en sistema: 87.3 minutos
====================================
```

**¿Qué significa cada KPI?**

| KPI | Significado | Valor Ideal |
|-----|-------------|-------------|
| **Throughput** | Pallets procesados por hora | 10-12 |
| **Utilización de Racks** | % de capacidad ocupada | 60-80% |
| **Tiempo en sistema** | Minutos desde entrada a salida | < 120 min |

---

## 🔧 Personalización Básica

### Cambiar el Tiempo de Simulación

En `BodegaTextil.fsm`, busca:
```
num stoptime: 28800  // 8 horas
```

Opciones comunes:
- 4 horas: 14400
- 12 horas: 43200
- 24 horas: 86400

### Cambiar el Tiempo de Packing

En `BodegaTextil.fsm`, busca:
```
num processtime: 600  // 10 minutos
```

Prueba con:
- Rápido: 300 (5 minutos)
- Lento: 900 (15 minutos)

### Cambiar la Frecuencia de Arribos

En `BodegaTextil.fsm`, busca:
```
num interarrivaltime: 300  // 5 minutos
```

Prueba con:
- Baja demanda: 600 (10 minutos)
- Alta demanda: 120 (2 minutos)

---

## 🎨 Visualización

### Cámaras y Vistas

**Vista Superior (Top View):**
1. Click derecho en el espacio 3D
2. Selecciona "View → Top"

**Vista Perspectiva:**
1. Click derecho en el espacio 3D
2. Selecciona "View → Perspective"

**Zoom:**
- Rueda del mouse para acercar/alejar
- Click derecho + arrastrar para rotar

### Seguir un Pallet

1. Haz click en un pallet (caja)
2. Ve a "View → Track Selected Object"
3. La cámara seguirá al pallet

---

## 📊 Estadísticas Detalladas

### Ver Estadísticas de un Objeto

1. Haz click en cualquier objeto (rack, queue, processor)
2. Ve a la pestaña "Statistics" en el panel lateral
3. Verás:
   - Input: Cantidad de items que entraron
   - Output: Cantidad de items que salieron
   - Content: Cantidad actual
   - Staytime: Tiempo promedio de estadía

### Dashboard de Estadísticas

1. Ve a **Dashboard → Statistics**
2. Verás gráficos de:
   - Throughput en tiempo real
   - Utilización de recursos
   - Work in Progress (WIP)

---

## ❓ Preguntas Frecuentes

### ¿Por qué no veo pallets moviéndose?

**Posibles causas:**
1. No ejecutaste el script `ConfiguracionProcesos.fs`
2. La simulación está pausada (presiona ▶)
3. La velocidad está en 0 (ajusta el slider)

**Solución:**
- Click en Reset (⟲)
- Ejecuta el script desde Tools → Script Console
- Click en Run (▶)

---

### ¿Por qué la apiladora no se mueve?

**Causa probable:** No hay pallets destinados a niveles altos

**Explicación:** La apiladora solo se usa para alturas > 2.5m. Si todos los racks bajos están vacíos, usará las transpaletas.

---

### ¿Cómo activo el packing alternativo?

**Opción 1: Aumentar demanda**
```flexscript
num interarrivaltime: 120  // Reducir tiempo entre arribos
```

**Opción 2: Reducir umbral de activación**

En `ConfiguracionProcesos.fs`, busca:
```flexscript
if (pallets_espera > 15)
```

Cámbialo a:
```flexscript
if (pallets_espera > 5)
```

---

### ¿Cómo veo qué hay en la zona de merma?

1. Click en "Queue_Merma" (zona roja en la esquina)
2. Ve a "Statistics → Content"
3. Verás los items actuales

**Nota:** La merma se revisa PRIMERO antes de ir a los racks.

---

## 🔍 Validación del Modelo

### Verificar que Todo Funciona

Ejecuta estos checks:

**✓ Check 1: Conexiones**
```
Source_Recepcion → Queue_Recepcion → Racks → Queue_Packing → Sink
```

**✓ Check 2: Equipamiento**
- Apiladora moviéndose a racks altos
- Transpaletas moviéndose a zonas bajas

**✓ Check 3: Categorización**
- BLUSA_OUTDOOR → Rack B1
- HOMBRE → Racks B4, B7, B8
- MUJER → Racks B5, B6
- Alta rotación → Racks C1-C4

**✓ Check 4: KPIs al Final**
Los KPIs deben aparecer en la consola cuando termine la simulación.

---

## 📚 Documentación Adicional

### Archivos Incluidos

| Archivo | Propósito |
|---------|-----------|
| `BodegaTextil.fsm` | Modelo principal FlexSim |
| `ConfiguracionProcesos.fs` | Script de lógica operacional |
| `README.md` | Documentación completa |
| `ESPECIFICACIONES_TECNICAS.md` | Detalles técnicos |
| `LAYOUT_VISUAL.txt` | Diagrama visual de la bodega |
| `datos_productos.csv` | Datos de ejemplo de productos |
| `GUIA_INICIO_RAPIDO.md` | Este archivo |

### Aprender Más

**FlexSim Basics:**
- [FlexSim Manual](https://docs.flexsim.com)
- [Tutorial Videos](https://www.flexsim.com/tutorials)

**FlexScript Programming:**
- [FlexScript Reference](https://docs.flexsim.com/flexscript)
- [Command Reference](https://docs.flexsim.com/reference)

---

## 🆘 Solución de Problemas

### El modelo no carga

**Error:** "Unable to open file"
- Verifica que tienes FlexSim 2019 o superior
- Verifica que el archivo no está corrupto
- Intenta abrir desde File → Open (no arrastrar)

---

### Los objetos están fuera de lugar

**Error:** Racks o zonas mal posicionadas
- Click en Reset
- Ejecuta `ConfiguracionProcesos.fs` de nuevo
- Si persiste, revisa las coordenadas en el archivo .fsm

---

### No veo los KPIs al final

**Solución:**
1. Abre la Script Console (Tools → Script Console)
2. Los KPIs se imprimen ahí cuando la simulación termina
3. Si no aparecen, ejecuta manualmente:
```flexscript
calcularKPIs();
```

---

### La simulación es muy lenta

**Optimización:**
1. Reduce la velocidad de visualización (desactiva 3D)
2. Ve a View → Disable 3D
3. Usa solo vista 2D para mayor velocidad

---

## 💡 Consejos Pro

### 1. Exportar Resultados a Excel
```
Dashboard → Statistics → Export → CSV
```

### 2. Comparar Escenarios
1. Ejecuta simulación con configuración A
2. Guarda resultados
3. Cambia parámetros (configuración B)
4. Ejecuta de nuevo
5. Compara KPIs

### 3. Crear Animaciones
```
Tools → Recorder → Record Animation
```

### 4. Experimentar sin Miedo
- Siempre puedes volver al modelo original
- Guarda copias antes de hacer cambios grandes
- Usa "Save As" para crear versiones

---

## 🎓 Próximos Pasos

Una vez que domines lo básico:

### Nivel Intermedio:
- [ ] Modificar distribuciones de probabilidad
- [ ] Agregar más categorías de productos
- [ ] Cambiar layout de racks
- [ ] Implementar turnos de trabajo

### Nivel Avanzado:
- [ ] Crear dashboard personalizado
- [ ] Implementar optimización de rutas
- [ ] Agregar análisis de costos
- [ ] Integrar con bases de datos externas

---

## 📞 Soporte

**Preguntas sobre FlexSim:**
- https://answers.flexsim.com

**Documentación del modelo:**
- Ver `README.md` (documentación completa)
- Ver `ESPECIFICACIONES_TECNICAS.md` (detalles técnicos)

**Reportar problemas:**
- Revisa los archivos de documentación primero
- Verifica que seguiste todos los pasos de configuración

---

## ✅ Lista de Verificación de Inicio

Antes de empezar, asegúrate de:

- [ ] FlexSim instalado (versión 2019+)
- [ ] Todos los archivos descargados en la misma carpeta
- [ ] Has leído esta guía completa
- [ ] Tienes al menos 30 minutos para explorar

**¡Estás listo para empezar!**

---

**Autor:** Claude AI
**Fecha:** 2025-11-09
**Versión:** 1.0
**Compatibilidad:** FlexSim 2019+

---

## 🎯 Tu Primera Simulación en 60 Segundos

1. **Abre** `BodegaTextil.fsm` en FlexSim
2. **Ejecuta** el script `ConfiguracionProcesos.fs`
3. **Click** en Reset (⟲)
4. **Click** en Run (▶)
5. **Observa** los pallets moviéndose
6. **Espera** a que termine (o acelera con el slider)
7. **Lee** los KPIs en la consola

**¡Felicidades! Ya ejecutaste tu primera simulación.**

---

**FIN DE LA GUÍA DE INICIO RÁPIDO**
