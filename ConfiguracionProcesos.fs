// ============================================
// SCRIPT DE CONFIGURACIÓN DE PROCESOS
// Bodega de Distribución Textil
// ============================================

// Este script configura las conexiones y lógica operacional
// del modelo de bodega textil en FlexSim

// ============================================
// 1. CONFIGURACIÓN DE CONEXIONES ENTRE OBJETOS
// ============================================

void setupConnections() {
    // Conexiones desde Source de Recepción
    contextdragconnection(Model.find("Source_Recepcion"), Model.find("Queue_Recepcion"), "A");

    // Desde Queue Recepción hacia Racks (distribución inteligente)
    contextdragconnection(Model.find("Queue_Recepcion"), Model.find("Rack_A1"), "A");
    contextdragconnection(Model.find("Queue_Recepcion"), Model.find("Rack_A2"), "A");
    contextdragconnection(Model.find("Queue_Recepcion"), Model.find("Rack_A3"), "A");
    contextdragconnection(Model.find("Queue_Recepcion"), Model.find("Rack_A4"), "A");
    contextdragconnection(Model.find("Queue_Recepcion"), Model.find("Rack_B1"), "A");
    contextdragconnection(Model.find("Queue_Recepcion"), Model.find("Rack_B2"), "A");
    contextdragconnection(Model.find("Queue_Recepcion"), Model.find("Rack_B3"), "A");
    contextdragconnection(Model.find("Queue_Recepcion"), Model.find("Rack_B4"), "A");
    contextdragconnection(Model.find("Queue_Recepcion"), Model.find("Rack_B5"), "A");
    contextdragconnection(Model.find("Queue_Recepcion"), Model.find("Rack_B6"), "A");
    contextdragconnection(Model.find("Queue_Recepcion"), Model.find("Rack_B7"), "A");
    contextdragconnection(Model.find("Queue_Recepcion"), Model.find("Rack_B8"), "A");
    contextdragconnection(Model.find("Queue_Recepcion"), Model.find("Rack_C1"), "A");
    contextdragconnection(Model.find("Queue_Recepcion"), Model.find("Rack_C2"), "A");
    contextdragconnection(Model.find("Queue_Recepcion"), Model.find("Rack_C3"), "A");
    contextdragconnection(Model.find("Queue_Recepcion"), Model.find("Rack_C4"), "A");

    // Desde Racks hacia Zona de Packing Principal
    contextdragconnection(Model.find("Rack_A1"), Model.find("Queue_PackingPrincipal"), "A");
    contextdragconnection(Model.find("Rack_A2"), Model.find("Queue_PackingPrincipal"), "A");
    contextdragconnection(Model.find("Rack_A3"), Model.find("Queue_PackingPrincipal"), "A");
    contextdragconnection(Model.find("Rack_A4"), Model.find("Queue_PackingPrincipal"), "A");
    contextdragconnection(Model.find("Rack_B1"), Model.find("Queue_PackingPrincipal"), "A");
    contextdragconnection(Model.find("Rack_B2"), Model.find("Queue_PackingPrincipal"), "A");
    contextdragconnection(Model.find("Rack_B3"), Model.find("Queue_PackingPrincipal"), "A");
    contextdragconnection(Model.find("Rack_B4"), Model.find("Queue_PackingPrincipal"), "A");
    contextdragconnection(Model.find("Rack_B5"), Model.find("Queue_PackingPrincipal"), "A");
    contextdragconnection(Model.find("Rack_B6"), Model.find("Queue_PackingPrincipal"), "A");
    contextdragconnection(Model.find("Rack_B7"), Model.find("Queue_PackingPrincipal"), "A");
    contextdragconnection(Model.find("Rack_B8"), Model.find("Queue_PackingPrincipal"), "A");
    contextdragconnection(Model.find("Rack_C1"), Model.find("Queue_PackingPrincipal"), "A");
    contextdragconnection(Model.find("Rack_C2"), Model.find("Queue_PackingPrincipal"), "A");
    contextdragconnection(Model.find("Rack_C3"), Model.find("Queue_PackingPrincipal"), "A");
    contextdragconnection(Model.find("Rack_C4"), Model.find("Queue_PackingPrincipal"), "A");

    // Desde Queue Merma hacia Packing (prioridad)
    contextdragconnection(Model.find("Queue_Merma"), Model.find("Queue_PackingPrincipal"), "A");

    // Desde Packing Principal hacia Procesador
    contextdragconnection(Model.find("Queue_PackingPrincipal"), Model.find("Processor_Packing"), "A");

    // Desde Procesador hacia Salida
    contextdragconnection(Model.find("Processor_Packing"), Model.find("Sink_Salida"), "A");

    // Desde Racks hacia Packing Alternativo (para pedidos grandes)
    contextdragconnection(Model.find("Rack_A1"), Model.find("Queue_PackingAlternativo"), "A");
    contextdragconnection(Model.find("Rack_A2"), Model.find("Queue_PackingAlternativo"), "A");
    contextdragconnection(Model.find("Rack_A3"), Model.find("Queue_PackingAlternativo"), "A");
    contextdragconnection(Model.find("Rack_A4"), Model.find("Queue_PackingAlternativo"), "A");

    // Desde Packing Alternativo hacia Salida
    contextdragconnection(Model.find("Queue_PackingAlternativo"), Model.find("Sink_Salida"), "A");
}

// ============================================
// 2. LÓGICA DE DISTRIBUCIÓN DE PALLETS
// ============================================

// Esta función decide a qué rack enviar cada pallet
Object determinarRackDestino(Object item) {
    // Obtener categoría del producto (simulado con labels)
    string categoria = item.getLabel("categoria", "GENERAL");

    // REGLA 1: Si el pallet viene de MERMA, va directo a packing
    if (item.getLabel("origen", "") == "MERMA") {
        return Model.find("Queue_PackingPrincipal");
    }

    // REGLA 2: Distribución por categoría
    if (categoria == "BLUSA_OUTDOOR") return Model.find("Rack_B1");
    if (categoria == "PARKA_NEW") return Model.find("Rack_B2");
    if (categoria == "CAMISA_OUTDOOR") return Model.find("Rack_B3");
    if (categoria == "HOMBRE") {
        // Distribuir entre racks de hombre
        double random = uniform(0, 1);
        if (random < 0.33) return Model.find("Rack_B4");
        else if (random < 0.67) return Model.find("Rack_B7");
        else return Model.find("Rack_B8");
    }
    if (categoria == "MUJER") {
        // Distribuir entre racks de mujer
        double random = uniform(0, 1);
        if (random < 0.5) return Model.find("Rack_B5");
        else return Model.find("Rack_B6");
    }

    // REGLA 3: Picking rápido para alta rotación
    if (item.getLabel("rotacion", "") == "ALTA") {
        int racknum = duniform(1, 4);
        return Model.find("Rack_C" + string.fromNum(racknum));
    }

    // REGLA 4: Almacenamiento masivo (racks grandes)
    // Distribuir entre los 4 racks tipo A
    int racknum = duniform(1, 4);
    return Model.find("Rack_A" + string.fromNum(racknum));
}

// ============================================
// 3. LÓGICA DE ASIGNACIÓN DE EQUIPAMIENTO
// ============================================

// Esta función decide qué equipamiento usar para cada tarea
Object asignarEquipamiento(Object item, Object destino) {
    // Obtener altura del destino
    double altura = destino.location.z;

    // REGLA 1: Apiladoras para niveles altos (> 2.5m)
    if (altura > 2.5) {
        return Model.find("TaskExecuter_Apiladora");
    }

    // REGLA 2: Transpaletas para niveles bajos
    // Seleccionar la transpaleta más cercana disponible
    Object tp1 = Model.find("Operator_Transpaleta1");
    Object tp2 = Model.find("Operator_Transpaleta2");

    double dist1 = distancefrom(tp1, item);
    double dist2 = distancefrom(tp2, item);

    if (dist1 < dist2) return tp1;
    else return tp2;
}

// ============================================
// 4. LÓGICA DE ACTIVACIÓN DE PACKING ALTERNATIVO
// ============================================

// Esta función decide si activar el packing alternativo
int activarPackingAlternativo() {
    // Contar pallets en cola de packing principal
    Object queuePrincipal = Model.find("Queue_PackingPrincipal");
    int numPallets = queuePrincipal.subnodes.length;

    // REGLA: Activar si hay más de 15 pallets esperando
    if (numPallets > 15) {
        return 1;  // Activado
    }

    // REGLA 2: Activar si hay pedidos grandes (> 200 cajas)
    // Esto se simularía con una variable global o label
    int cajasEnPedido = Model.getVariable("cajas_pedido_actual", 0);
    if (cajasEnPedido > 200) {
        return 1;  // Activado
    }

    return 0;  // Desactivado
}

// ============================================
// 5. LÓGICA DE GESTIÓN DE MERMA
// ============================================

// Esta función gestiona la revisión de merma antes de picking
int verificarDisponibilidadEnMerma(string producto) {
    Object queueMerma = Model.find("Queue_Merma");

    // Buscar en la cola de merma si hay el producto solicitado
    for (int i = 1; i <= queueMerma.subnodes.length; i++) {
        Object item = queueMerma.subnodes[i];
        if (item.getLabel("producto", "") == producto) {
            return 1;  // Encontrado en merma
        }
    }

    return 0;  // No disponible en merma, ir a racks
}

// ============================================
// 6. ESTADÍSTICAS Y KPIs
// ============================================

void calcularKPIs() {
    // Throughput (pallets procesados por hora)
    double tiempoSimulacion = Model.time / 3600;  // Convertir a horas
    int palletsProcesados = Model.find("Sink_Salida").getStatNum("Input");
    double throughput = palletsProcesados / tiempoSimulacion;

    // Utilización de racks
    double utilizacionRacks = 0;
    int numRacks = 16;  // 4 tipo A + 8 tipo B + 4 tipo C

    for (int i = 1; i <= 4; i++) {
        Object rack = Model.find("Rack_A" + string.fromNum(i));
        utilizacionRacks += rack.subnodes.length / rack.getVariable("capacity", 24);
    }
    for (int i = 1; i <= 8; i++) {
        Object rack = Model.find("Rack_B" + string.fromNum(i));
        utilizacionRacks += rack.subnodes.length / rack.getVariable("capacity", 12);
    }
    for (int i = 1; i <= 4; i++) {
        Object rack = Model.find("Rack_C" + string.fromNum(i));
        utilizacionRacks += rack.subnodes.length / rack.getVariable("capacity", 6);
    }

    utilizacionRacks = (utilizacionRacks / numRacks) * 100;

    // Tiempo promedio en sistema
    double tiempoPromedio = Model.find("Sink_Salida").getStatNum("Staytime");

    // Imprimir resultados
    print("======== KPIs BODEGA TEXTIL ========");
    print("Throughput: " + string.fromNum(throughput) + " pallets/hora");
    print("Utilización de Racks: " + string.fromNum(utilizacionRacks) + "%");
    print("Tiempo promedio en sistema: " + string.fromNum(tiempoPromedio/60) + " minutos");
    print("====================================");
}

// ============================================
// 7. FUNCIÓN DE INICIALIZACIÓN
// ============================================

void inicializarModelo() {
    print("Inicializando modelo de Bodega Textil...");

    // Configurar conexiones
    setupConnections();

    // Configurar variables globales
    Model.setVariable("cajas_pedido_actual", 0);
    Model.setVariable("modo_packing_alternativo", 0);

    // Configurar labels iniciales en pallets
    // Esto se hará en el evento OnCreation del Source

    print("Modelo inicializado correctamente.");
    print("Dimensiones: 25m x 15m x 5m");
    print("Total Racks: 16 (4 Tipo A + 8 Tipo B + 4 Tipo C)");
    print("Capacidad total: 264 pallets");
    print("Equipamiento: 1 Apiladora + 2 Transpaletas");
    print("Tiempo de simulación: 8 horas (28800 segundos)");
}

// ============================================
// 8. EVENTOS DEL MODELO
// ============================================

// OnModelReset - Se ejecuta al reiniciar el modelo
void OnModelReset() {
    inicializarModelo();
}

// OnRunStart - Se ejecuta al iniciar la simulación
void OnRunStart() {
    print("Iniciando simulación...");
    resetstatistics();
}

// OnRunStop - Se ejecuta al detener la simulación
void OnRunStop() {
    print("Simulación completada.");
    calcularKPIs();
}

// OnCreation (Source_Recepcion) - Asignar categoría a pallets
void OnCreation_Source(Object item) {
    // Asignar categoría aleatoria
    double rand = uniform(0, 1);

    if (rand < 0.15) item.setLabel("categoria", "BLUSA_OUTDOOR");
    else if (rand < 0.30) item.setLabel("categoria", "PARKA_NEW");
    else if (rand < 0.45) item.setLabel("categoria", "CAMISA_OUTDOOR");
    else if (rand < 0.70) item.setLabel("categoria", "HOMBRE");
    else item.setLabel("categoria", "MUJER");

    // Asignar rotación
    if (uniform(0, 1) < 0.25) item.setLabel("rotacion", "ALTA");
    else item.setLabel("rotacion", "NORMAL");

    // Asignar número de cajas por pallet
    item.setLabel("num_cajas", duniform(20, 40));

    // Color según categoría
    if (item.getLabel("categoria", "") == "HOMBRE") item.setColor(0x0000FFFF);
    else if (item.getLabel("categoria", "") == "MUJER") item.setColor(0xFF00FFFF);
    else item.setColor(0xFFFF00FF);
}

// OnEntry (Queue_Recepcion) - Decidir destino
void OnEntry_Queue(Object item) {
    Object destino = determinarRackDestino(item);
    item.setLabel("destino_asignado", destino.getName());
}

// ============================================
// EJECUTAR INICIALIZACIÓN
// ============================================
inicializarModelo();
