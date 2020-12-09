//const proxyCORS = "https://cors-anywhere.herokuapp.com/"; // demo: https://robwu.nl/cors-anywhere.html
//const proxyCORS = "";
//const URI = "http://restfulservice.gear.host/api/SmartPhones/";

const config = { databaseURL: "https://sademo-fa5ba-default-rtdb.firebaseio.com/" };
firebase.initializeApp(config);
const dbRef = firebase.database().ref();

/* event-handler methods */
function page_Load() {
  getAll();
}

function lnkID_Click(code) {
  getDetails(code);
}

function btnSearch_Click() {
  var keyword = document.getElementById("txtKeyword").value.trim();
  if (keyword.length > 0)
    search(keyword);
  else
    getAll();
}

function btnAdd_Click() {
  var newSmartPhone = {
    Code: document.getElementById("txtCode").value,
    Name: document.getElementById("txtName").value,
    Brand: document.getElementById("txtBrand").value,
    Price: document.getElementById("txtPrice").value,
	Color: document.getElementById("txtColor").value
  };
  addSmartPhone(newSmartPhone);
}

function btnUpdate_Click() {
  var newSmartPhone = {
    Code: document.getElementById("txtCode").value,
    Name: document.getElementById("txtName").value,
    Brand: document.getElementById("txtBrand").value,
    Price: document.getElementById("txtPrice").value,
	Color: document.getElementById("txtColor").value
  };
  updateSmartPhone(newSmartPhone);
}

function btnDelete_Click() {
  if (confirm("ARE YOU SURE ?")) {
    var code = document.getElementById("txtCode").value;
    deleteSmartPhone(code);
  }
}

/* business methods */
/*function getAll() {
  axios.get(proxyCORS + URI).then((response) => {
    var SmartPhones = response.data;
    renderSmartPhoneList(SmartPhones);
  });
}

function getDetails(code) {
  axios.get(proxyCORS + URI + code).then((response) => {
    var SmartPhone = response.data;
    renderSmartPhoneDetails(SmartPhone);
  });
}

function search(keyword) {
  axios.get(proxyCORS + URI + "search/" + keyword).then((response) => {
    var SmartPhones = response.data;
    renderSmartPhoneList(SmartPhones);
  });
}

function addSmartPhone(newSmartPhone) {
  axios.post(proxyCORS + URI, newSmartPhone).then((response) => {
    var result = response.data;
    if (result) {
      getAll();
      clearTextboxes();
    } else {
      alert('NOW YOUR SYSTEM ERROR!');
    }
  });
}

function updateSmartPhone(newSmartPhone) {
  axios.put(proxyCORS + URI + newSmartPhone.Code, newSmartPhone).then((response) => {
    var result = response.data;
    if (result) {
      getAll();
      clearTextboxes();
    } else {
      alert('CANNOT UPDATE, TRY AGAIN');
    }
  });
}

function deleteSmartPhone(code) {
  axios.delete(proxyCORS + URI + code).then((response) => {
    var result = response.data;
    if (result) {
      getAll();
      clearTextboxes();
    } else {
      alert('SORRY CANNOT DELETE');
    }
  });
}*/

function getAll() {
  dbRef.child("Smartphones").on("value", (snapshot) => {
    var SmartPhones = [];
    snapshot.forEach((child) => {
      //alert(child.key);
      var SmartPhone = child.val();
      SmartPhones.push(SmartPhone);
    });
    renderSmartPhoneList(SmartPhones);
  });
}

function getDetails(code) {
  dbRef.child("Smartphones").once("value", (snapshot) => {
    snapshot.forEach((child) => {
      var SmartPhone = child.val();
      if (SmartPhone.Code == code) {
        renderSmartPhoneDetails(SmartPhone);
      }
    });
  });
}

function search(keyword) {
  dbRef.child("Smartphones").once("value", (snapshot) => {
    var SmartPhones = [];
    snapshot.forEach((child) => {
      var SmartPhone = child.val();
      if (SmartPhone.Name.includes(keyword)) {
        SmartPhones.push(SmartPhone);
      }
    });
    renderSmartPhoneList(SmartPhones);
  });
}

function addSmartPhone(newSmartPhone) {
  //dbRef.child("SmartPhones").push(newSmartPhone); // auto-generated key
  dbRef.child("Smartphones/SmartPhone Code: " + newSmartPhone.Code).set(newSmartPhone); // custom key
}

function updateSmartPhone(newSmartPhone) {
  dbRef.child("Smartphones").once("value", (snapshot) => {
    snapshot.forEach((child) => {
      var SmartPhone = child.val();
      if (SmartPhone.Code == newSmartPhone.Code) {
        var key = child.key;
        dbRef.child("Smartphones").child(key).set(newSmartPhone);
      }
    });
  });
}

function deleteSmartPhone(code) {
  dbRef.child("Smartphones").once("value", (snapshot) => {
    snapshot.forEach((child) => {
      var SmartPhone = child.val();
      if (SmartPhone.Code == code) {
        var key = child.key;
        dbRef.child("Smartphones").child(key).remove();
      }
    });
  });
}

/* helper methods */
function renderSmartPhoneList(SmartPhones) {
  var rows = "";
  for (var SmartPhone of SmartPhones) {
    rows += "<tr onclick='lnkID_Click(" + SmartPhone.Code + ")' style='cursor:pointer'>";
    rows += "<td>" + SmartPhone.Code + "</td>";
    rows += "<td>" + SmartPhone.Name + "</td>";
    rows += "<td>" + SmartPhone.Brand + "</td>";
    rows += "<td>" + SmartPhone.Price + "</td>";
	rows += "<td>" + SmartPhone.Color + "</td>";
    rows += "</tr>";
  }
  var header = "<tr><th>Code</th><th>Name</th><th>Brand</th><th>Price</th><th>Color</th></tr>";
  document.getElementById("lstSmartphones").innerHTML = header + rows;
}

function renderSmartPhoneDetails(SmartPhone) {
  document.getElementById("txtCode").value = SmartPhone.Code;
  document.getElementById("txtName").value = SmartPhone.Name;
  document.getElementById("txtBrand").value = SmartPhone.Brand;
  document.getElementById("txtPrice").value = SmartPhone.Price;
  document.getElementById("txtColor").value = SmartPhone.Color;
}

function clearTextboxes() {
  document.getElementById("txtCode").value = '';
  document.getElementById("txtName").value = '';
  document.getElementById("txtBrand").value = '';
  document.getElementById("txtPrice").value = '';
  document.getElementById("txtColor").value = '';
}