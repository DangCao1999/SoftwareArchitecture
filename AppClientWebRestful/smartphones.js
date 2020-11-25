const proxyCORS = "https://cors-anywhere.herokuapp.com/"; // demo: https://robwu.nl/cors-anywhere.html
//const proxyCORS = "";
const URI = "http://cao2246restful.gear.host/api/smartphones/";

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
  var newBook = {
    Code: 0,
    Name: document.getElementById("txtName").value,
    Price: document.getElementById("txtPrice").value,
    Brand: document.getElementById("txtBrand").value,
    Color: document.getElementById("txtColor").value,
  };
  addNew(newBook);
}

function btnUpdate_Click() {
  var newBook = {
    Code: document.getElementById("txtCode").value,
    Name: document.getElementById("txtName").value,
    Price: document.getElementById("txtPrice").value,
    Brand: document.getElementById("txtBrand").value,
    Color: document.getElementById("txtColor").value,
  };
  updateBook(newBook);
}

function btnDelete_Click() {
  if (confirm("ARE YOU SURE ?")) {
    var code = document.getElementById("txtCode").value;
    deleteBook(code);
  }
}

/* business methods */
function getAll() {
  axios.get(proxyCORS + URI).then((response) => {
    var books = response.data;
    renderBookList(books);
  });
}

function getDetails(code) {
  axios.get(proxyCORS + URI + code).then((response) => {
    var book = response.data;
    renderBookDetails(book);
  });
}

function search(keyword) {
  axios.get(proxyCORS + URI + "search/" + keyword).then((response) => {
    var books = response.data;
    renderBookList(books);
  });
}

function addNew(newBook) {
  axios.post(proxyCORS + URI, newBook).then((response) => {
    var result = response.data;
    if (result) {
      getAll();
      clearTextboxes();
    } else {
      alert('SORRY BABY!');
    }
  });
}

function updateBook(newBook) {
  axios.put(proxyCORS + URI, newBook).then((response) => {
    var result = response.data;
    if (result) {
      getAll();
      clearTextboxes();
    } else {
      alert('SORRY BABY!');
    }
  });
}

function deleteBook(code) {
  axios.delete(proxyCORS + URI + code).then((response) => {
    var result = response.data;
    if (result) {
      getAll();
      clearTextboxes();
    } else {
      alert('SORRY BABY!');
    }
  });
}

/* helper methods */
function renderBookList(books) {
  var rows = "";
  for (var book of books) {
    rows += "<tr onclick='lnkID_Click(" + book.Code + ")' style='cursor:pointer'>";
    rows += "<td>" + book.Code + "</td>";
    rows += "<td>" + book.Name + "</td>";
    rows += "<td>" + book.Price + "</td>";
    rows += "<td>" + book.Brand + "</td>";
    rows += "<td>" + book.Color + "</td>";
    rows += "</tr>";
  }
  var header = "<tr><th>Code</th><th>Name</th><th>Price</th><th>Brand</th><th>Color</th></tr>";
  document.getElementById("lstBooks").innerHTML = header + rows;
}

function renderBookDetails(book) {
  document.getElementById("txtCode").value = book.Code;
  document.getElementById("txtName").value = book.Name;
  document.getElementById("txtPrice").value = book.Price;
  document.getElementById("txtBrand").value = book.Brand;
  document.getElementById("txtColor").value = book.Color;
}

function clearTextboxes() {
  document.getElementById("txtCode").value = '';
  document.getElementById("txtName").value = '';
  document.getElementById("txtPrice").value = '';
  document.getElementById("txtBrand").value = '';
  document.getElementById("txtColor").value = '';
}