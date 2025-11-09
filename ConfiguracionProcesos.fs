// ============================================
// SCRIPT DE CONFIGURACIÓN DE PROCESOS
// Bodega de Distribución Textil
// ============================================

// Este script configura las conexiones y lógica operacional
// del modelo de bodega textil en FlexSim

// ============================================
// 1. CONFIGURACIÓN DE CONEXIONES ENTRE OBJETOS
// ============================================

// Helper function para búsqueda segura de nodos
treenode safeFind(string path) {
    treenode result = node(path, model());
    if (!objectexists(result)) {
        print("ADVERTENCIA: No se encontró el nodo: " + path);
        return NULL;
    }
    return result;
}

void setupConnections() {
    // Conexiones desde Source de Recepción
    treenode source = safeFind("Source_Recepcion");
    treenode queueRec = safeFind("Queue_Recepcion");
    if (source && queueRec) contextdragconnection(source, queueRec, "A");

    // Desde Queue Recepción hacia Racks (distribución inteligente)
    if (queueRec) {
        treenode rack;
        rack = safeFind("Rack_A1"); if (rack) contextdragconnection(queueRec, rack, "A");
        rack = safeFind("Rack_A2"); if (rack) contextdragconnection(queueRec, rack, "A");
        rack = safeFind("Rack_A3"); if (rack) contextdragconnection(queueRec, rack, "A");
        rack = safeFind("Rack_A4"); if (rack) contextdragconnection(queueRec, rack, "A");
        rack = safeFind("Rack_B1"); if (rack) contextdragconnection(queueRec, rack, "A");
        rack = safeFind("Rack_B2"); if (rack) contextdragconnection(queueRec, rack, "A");
        rack = safeFind("Rack_B3"); if (rack) contextdragconnection(queueRec, rack, "A");
        rack = safeFind("Rack_B4"); if (rack) contextdragconnection(queueRec, rack, "A");
        rack = safeFind("Rack_B5"); if (rack) contextdragconnection(queueRec, rack, "A");
        rack = safeFind("Rack_B6"); if (rack) contextdragconnection(queueRec, rack, "A");
        rack = safeFind("Rack_B7"); if (rack) contextdragconnection(queueRec, rack, "A");
        rack = safeFind("Rack_B8"); if (rack) contextdragconnection(queueRec, rack, "A");
        rack = safeFind("Rack_C1"); if (rack) contextdragconnection(queueRec, rack, "A");
        rack = safeFind("Rack_C2"); if (rack) contextdragconnection(queueRec, rack, "A");
        rack = safeFind("Rack_C3"); if (rack) contextdragconnection(queueRec, rack, "A");
        rack = safeFind("Rack_C4"); if (rack) contextdragconnection(queueRec, rack, "A");
    }

    // Desde Racks hacia Zona de Packing Principal
    treenode queuePacking = safeFind("Queue_PackingPrincipal");
    if (queuePacking) {
        treenode rack;
        rack = safeFind("Rack_A1"); if (rack) contextdragconnection(rack, queuePacking, "A");
        rack = safeFind("Rack_A2"); if (rack) contextdragconnection(rack, queuePacking, "A");
        rack = safeFind("Rack_A3"); if (rack) contextdragconnection(rack, queuePacking, "A");
        rack = safeFind("Rack_A4"); if (rack) contextdragconnection(rack, queuePacking, "A");
        rack = safeFind("Rack_B1"); if (rack) contextdragconnection(rack, queuePacking, "A");
        rack = safeFind("Rack_B2"); if (rack) contextdragconnection(rack, queuePacking, "A");
        rack = safeFind("Rack_B3"); if (rack) contextdragconnection(rack, queuePacking, "A");
        rack = safeFind("Rack_B4"); if (rack) contextdragconnection(rack, queuePacking, "A");
        rack = safeFind("Rack_B5"); if (rack) contextdragconnection(rack, queuePacking, "A");
        rack = safeFind("Rack_B6"); if (rack) contextdragconnection(rack, queuePacking, "A");
        rack = safeFind("Rack_B7"); if (rack) contextdragconnection(rack, queuePacking, "A");
        rack = safeFind("Rack_B8"); if (rack) contextdragconnection(rack, queuePacking, "A");
        rack = safeFind("Rack_C1"); if (rack) contextdragconnection(rack, queuePacking, "A");
        rack = safeFind("Rack_C2"); if (rack) contextdragconnection(rack, queuePacking, "A");
        rack = safeFind("Rack_C3"); if (rack) contextdragconnection(rack, queuePacking, "A");
        rack = safeFind("Rack_C4"); if (rack) contextdragconnection(rack, queuePacking, "A");
    }

    // Desde Queue Merma hacia Packing (prioridad)
    treenode queueMerma = safeFind("Queue_Merma");
    if (queueMerma && queuePacking) contextdragconnection(queueMerma, queuePacking, "A");

    // Desde Packing Principal hacia Procesador
    treenode processor = safeFind("Processor_Packing");
    if (queuePacking && processor) contextdragconnection(queuePacking, processor, "A");

    // Desde Procesador hacia Salida
    treenode sink = safeFind("Sink_Salida");
    if (processor && sink) contextdragconnection(processor, sink, "A");

    // Desde Racks hacia Packing Alternativo (para pedidos grandes)
    treenode queueAlt = safeFind("Queue_PackingAlternativo");
    if (queueAlt) {
        treenode rack;
        rack = safeFind("Rack_A1"); if (rack) contextdragconnection(rack, queueAlt, "A");
        rack = safeFind("Rack_A2"); if (rack) contextdragconnection(rack, queueAlt, "A");
        rack = safeFind("Rack_A3"); if (rack) contextdragconnection(rack, queueAlt, "A");
        rack = safeFind("Rack_A4"); if (rack) contextdragconnection(rack, queueAlt, "A");
    }

    // Desde Packing Alternativo hacia Salida
    if (queueAlt && sink) contextdragconnection(queueAlt, sink, "A");
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
        return safeFind("Queue_PackingPrincipal");
    }

    // REGLA 2: Distribución por categoría
    if (categoria == "BLUSA_OUTDOOR") return safeFind("Rack_B1");
    if (categoria == "PARKA_NEW") return safeFind("Rack_B2");
    if (categoria == "CAMISA_OUTDOOR") return safeFind("Rack_B3");
    if (categoria == "HOMBRE") {
        // Distribuir entre racks de hombre
        double random = uniform(0, 1);
        if (random < 0.33) return safeFind("Rack_B4");
        else if (random < 0.67) return safeFind("Rack_B7");
        else return safeFind("Rack_B8");
    }
    if (categoria == "MUJER") {
        // Distribuir entre racks de mujer
        double random = uniform(0, 1);
        if (random < 0.5) return safeFind("Rack_B5");
        else return safeFind("Rack_B6");
    }

    // REGLA 3: Picking rápido para alta rotación
    if (item.getLabel("rotacion", "") == "ALTA") {
        int racknum = duniform(1, 4);
        return safeFind("Rack_C" + string.fromNum(racknum));
    }

    // REGLA 4: Almacenamiento masivo (racks grandes)
    // Distribuir entre los 4 racks tipo A
    int racknum = duniform(1, 4);
    return safeFind("Rack_A" + string.fromNum(racknum));
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
        return safeFind("TaskExecuter_Apiladora");
    }

    // REGLA 2: Transpaletas para niveles bajos
    // Seleccionar la transpaleta más cercana disponible
    Object tp1 = safeFind("Operator_Transpaleta1");
    Object tp2 = safeFind("Operator_Transpaleta2");

    if (!tp1 || !tp2) return tp1 ? tp1 : tp2;

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
    Object queuePrincipal = safeFind("Queue_PackingPrincipal");
    if (!queuePrincipal) return 0;

    int numPallets = queuePrincipal.subnodes.length;

    // REGLA: Activar si hay más de 15 pallets esperando
    if (numPallets > 15) {
        return 1;  // Activado
    }

    // REGLA 2: Activar si hay pedidos grandes (> 200 cajas)
    // Esto se simularía con una variable global o label
    treenode varNode = node("?variables/cajas_pedido_actual", model());
    int cajasEnPedido = 0;
    if (objectexists(varNode)) cajasEnPedido = varNode.value;

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
    Object queueMerma = safeFind("Queue_Merma");
    if (!queueMerma) return 0;

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
    double tiempoSimulacion = model().time / 3600;  // Convertir a horas
    Object sink = safeFind("Sink_Salida");
    if (!sink) {
        print("ERROR: No se puede calcular KPIs - Sink_Salida no encontrado");
        return;
    }

    int palletsProcesados = sink.getStatNum("Input");
    double throughput = (tiempoSimulacion > 0) ? palletsProcesados / tiempoSimulacion : 0;

    // Utilización de racks
    double utilizacionRacks = 0;
    int numRacksValidos = 0;

    for (int i = 1; i <= 4; i++) {
        Object rack = safeFind("Rack_A" + string.fromNum(i));
        if (rack && objectexists(rack)) {
            treenode capNode = node("?capacity", rack);
            double cap = objectexists(capNode) ? capNode.value : 24;
            utilizacionRacks += rack.subnodes.length / cap;
            numRacksValidos++;
        }
    }
    for (int i = 1; i <= 8; i++) {
        Object rack = safeFind("Rack_B" + string.fromNum(i));
        if (rack && objectexists(rack)) {
            treenode capNode = node("?capacity", rack);
            double cap = objectexists(capNode) ? capNode.value : 12;
            utilizacionRacks += rack.subnodes.length / cap;
            numRacksValidos++;
        }
    }
    for (int i = 1; i <= 4; i++) {
        Object rack = safeFind("Rack_C" + string.fromNum(i));
        if (rack && objectexists(rack)) {
            treenode capNode = node("?capacity", rack);
            double cap = objectexists(capNode) ? capNode.value : 6;
            utilizacionRacks += rack.subnodes.length / cap;
            numRacksValidos++;
        }
    }

    utilizacionRacks = (numRacksValidos > 0) ? (utilizacionRacks / numRacksValidos) * 100 : 0;

    // Tiempo promedio en sistema
    double tiempoPromedio = sink.getStatNum("Staytime");

    // Imprimir resultados
    print("======== KPIs BODEGA TEXTIL ========");
    print("Throughput: " + string.fromNum(throughput) + " pallets/hora");
    print("Utilización de Racks: " + string.fromNum(utilizacionRacks) + "%");
    print("Tiempo promedio en sistema: " + string.fromNum(tiempoPromedio/60) + " minutos");
    print("Racks válidos encontrados: " + string.fromNum(numRacksValidos));
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
    treenode varsNode = node("?variables", model());
    if (!objectexists(varsNode)) {
        varsNode = createnode("variables", model());
    }

    treenode varNode = node("?cajas_pedido_actual", varsNode);
    if (!objectexists(varNode)) {
        varNode = createcoupling("cajas_pedido_actual", varsNode);
    }
    varNode.value = 0;

    varNode = node("?modo_packing_alternativo", varsNode);
    if (!objectexists(varNode)) {
        varNode = createcoupling("modo_packing_alternativo", varsNode);
    }
    varNode.value = 0;

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
