<script src="https://www.gstatic.com/firebasejs/8.2.5/firebase-app.js"></script>
    <script src="https://www.gstatic.com/firebasejs/8.2.5/firebase-firestore.js"></script>

const firebase = require("firebase");
// Required for side-effects
require("firebase/firestore");

// Initialize Cloud Firestore through Firebase
firebase.initializeApp({
    apiKey: '### FIREBASE API KEY ###',
    authDomain: '### FIREBASE AUTH DOMAIN ###',
    projectId: '### CLOUD FIRESTORE PROJECT ID ###'
});

var db = firebase.firestore();
db.collection("users").get().then((querySnapshot) => {
    querySnapshot.forEach((doc) => {
        console.log(`${doc.id} => ${doc.data()}`);
    });
});