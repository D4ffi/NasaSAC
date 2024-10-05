import * as THREE from 'three';
import { OrbitControls } from './OrbitControls.js';
import { GLTFLoader } from 'three/examples/jsm/loaders/GLTFLoader.js';

// Crear la escena, la cámara y el renderer
const scene = new THREE.Scene();
const camera = new THREE.PerspectiveCamera(75, window.innerWidth / window.innerHeight, 0.1, 1000);
const renderer = new THREE.WebGLRenderer({
    canvas: document.getElementById('earthCanvas'),
    antialias: true
});
renderer.setSize(window.innerWidth, window.innerHeight);

// Agregar una luz ambiental a la escena
const ambientLight = new THREE.AmbientLight(0xffffff, 0.5);
scene.add(ambientLight);

// Agregar una luz direccional a la escena
const directionalLight = new THREE.DirectionalLight(0xffffff, 1);
directionalLight.position.set(10, 10, 10);
scene.add(directionalLight);

// Cargar el modelo GLB
const loader = new GLTFLoader();
loader.load('/models/Files/earth.glb', function (gltf) {
    console.log('Model loaded successfully');
    scene.add(gltf.scene);
}, undefined, function (error) {
    console.error('Error loading model:', error);
});

// Configurar la cámara
camera.position.z = 10;

// Configurar los controles de órbita
const controls = new OrbitControls(camera, renderer.domElement);
controls.enableDamping = true;
controls.dampingFactor = 0.05;
controls.screenSpacePanning = false;
controls.minDistance = 1;
controls.maxDistance = 1000;

// Función de animación
function animate() {
    requestAnimationFrame(animate);
    controls.update();
    renderer.render(scene, camera);
}

// Iniciar la animación
animate();