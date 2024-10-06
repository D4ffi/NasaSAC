let isDragging = false;
let previousMousePosition = { x: 0, y: 0 };
let camera, scene, renderer, raycaster, mouse, originalCameraPosition;
let selectedPlanet = null;
let isZoomed = false; // Variable para controlar si estamos en zoom o no

function init() {
    // Crear la escena
    scene = new THREE.Scene();
    camera = new THREE.PerspectiveCamera(75, window.innerWidth / window.innerHeight, 0.1, 1000);
    renderer = new THREE.WebGLRenderer({ antialias: true });
    renderer.setSize(window.innerWidth, window.innerHeight);
    document.getElementById('threejs-container').appendChild(renderer.domElement);

    // Guardar la posición original de la cámara
    originalCameraPosition = new THREE.Vector3(0, 10, 30);

    // Agregar un fondo estrellado
    const spaceTexture = new THREE.TextureLoader().load('/images/space_texture.jpg');
    scene.background = spaceTexture;

    // Inicializar raycaster y mouse
    raycaster = new THREE.Raycaster();
    mouse = new THREE.Vector2();

    // Función para crear un planeta
    function createPlanet(size, texturePath, position) {
        const geometry = new THREE.SphereGeometry(size, 32, 32);
        const texture = new THREE.TextureLoader().load(texturePath);
        const material = new THREE.MeshBasicMaterial({ map: texture });
        const planet = new THREE.Mesh(geometry, material);
        planet.position.set(position.x, position.y, position.z);
        scene.add(planet);
        return planet;
    }

    // Función para crear una órbita
    function createOrbit(radius) {
        const geometry = new THREE.CircleGeometry(radius, 64);
        const material = new THREE.LineBasicMaterial({ color: 0xFFFFFF, opacity: 0.5, transparent: true });
        const orbit = new THREE.LineLoop(geometry, material);
        orbit.rotation.x = Math.PI / 2; // Girar la órbita para que esté en el plano XY
        scene.add(orbit);
        return orbit;
    }

    // Crear los 8 planetas y sus órbitas
    const planets = [];
    planets.push({ planet: createPlanet(0.5, '/images/planet_texture.jpg', { x: 2, y: 0, z: 0 }), orbit: createOrbit(2) }); // Mercurio
    planets.push({ planet: createPlanet(0.9, '/images/planet_texture1.jpg', { x: 4, y: 0, z: 0 }), orbit: createOrbit(4) }); // Venus
    planets.push({ planet: createPlanet(1, '/images/planet_texture2.jpg', { x: 6, y: 0, z: 0 }), orbit: createOrbit(6) }); // Tierra
    planets.push({ planet: createPlanet(0.7, '/images/planet_texture3.jpg', { x: 8, y: 0, z: 0 }), orbit: createOrbit(8) }); // Marte
    planets.push({ planet: createPlanet(1.5, '/images/planet_texture4.jpg', { x: 10, y: 0, z: 0 }), orbit: createOrbit(10) }); // Júpiter
    planets.push({ planet: createPlanet(1.3, '/images/planet_texture5.jpg', { x: 12, y: 0, z: 0 }), orbit: createOrbit(12) }); // Saturno
    planets.push({ planet: createPlanet(1, '/images/planet_texture6.jpg', { x: 14, y: 0, z: 0 }), orbit: createOrbit(14) }); // Urano
    planets.push({ planet: createPlanet(1, '/images/planet_texture7.jpg', { x: 16, y: 0, z: 0 }), orbit: createOrbit(16) }); // Neptuno

    // Ajustar la posición de la cámara para que todos los planetas sean visibles
    camera.position.copy(originalCameraPosition);

    // Función de animación
    function animate() {
        requestAnimationFrame(animate);

        // Animar los planetas en sus órbitas
        const time = Date.now() * 0.0002; // Reducir el factor de tiempo para que los planetas se muevan más lento
        planets.forEach((p, index) => {
            const radius = 2 + index * 2; // Ajustar la distancia para cada planeta
            p.planet.position.x = Math.cos(time + index) * radius;
            p.planet.position.z = Math.sin(time + index) * radius;
        });

        renderer.render(scene, camera);
    }

    animate();

    // Detectar clics en los planetas
    window.addEventListener('click', (event) => {
        mouse.x = (event.clientX / window.innerWidth) * 2 - 1;
        mouse.y = -(event.clientY / window.innerHeight) * 2 + 1;

        raycaster.setFromCamera(mouse, camera);
        const intersects = raycaster.intersectObjects(planets.map(p => p.planet));

        if (intersects.length > 0) {
            const clickedPlanet = intersects[0].object;
            if (clickedPlanet === selectedPlanet && isZoomed) {
                zoomOut(); // Si el planeta ya está seleccionado, alejar la cámara
            } else {
                zoomInOnPlanet(clickedPlanet); // Si es un nuevo planeta, hacer zoom
            }
        }
    });

    // Función para hacer zoom en el planeta seleccionado
    function zoomInOnPlanet(planet) {
        selectedPlanet = planet;
        const targetPosition = new THREE.Vector3();
        planet.getWorldPosition(targetPosition);
        camera.position.set(targetPosition.x + 3, targetPosition.y + 1, targetPosition.z + 5);
        camera.lookAt(targetPosition);
        isZoomed = true;
    }

    // Función para alejar (restablecer la posición original de la cámara)
    function zoomOut() {
        camera.position.copy(originalCameraPosition);
        camera.lookAt(0, 0, 0); // Asegurarse de que la cámara apunte al centro de la escena
        selectedPlanet = null;
        isZoomed = false;
    }
}

window.onload = init;
