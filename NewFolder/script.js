let url = "http://localhost:5038/api";
//Get all Categories in table
fetch( "http://localhost:5038/api/CategoryModels")
  .then(res => {
    return res.json();
  })
  .then(data => {
    let tableData = "";
    data.map((values) => {
      tableData += `<tr>
        <th>${values.categoryName}</th>
        <th>${values.categoryLimit}</th>
        <th class="actions"><i class="fa-solid fa-pen-to-square" id="cat-edit" style=" cursor: pointer;"></i>
          <i class="fa-solid fa-trash" style="cursor: pointer;"></i></th></tr>`;
});
    document.getElementById("cat-table").innerHTML = tableData;
  }).catch((err) => {
    console.log(err);
  })

// Get all transactions in table
fetch(url + "/Expense")
  .then(res => {
    return res.json();
  })
  .then(data => {
    let tableData = "";
    data.map((values) => {
      tableData += `<tr>
        <th>${values.expenseName}</th>
        <th>${values.description}</th>
        <th>${values.categoryName}</th>
        <th>${values.amount}</th>
        
<th class="actions"><i class="fa-solid fa-pen-to-square" style=" cursor: pointer;"></i>
          <i class="fa-solid fa-trash" style="cursor: pointer;"></i></th></tr>`;
    });
    document.getElementById("exp-table").innerHTML = tableData;
  }).catch((err) => {
    console.log(err);
  })

  








  var CatForm = document.getElementById('cat-sub'); 
  CatForm.addEventListener('click', function (e)

{
    e.preventDefault();

var name = document.getElementById('cat-name').value 
var limit  = document.getElementById('cat-limit').value

const formData = (name , limit );

fetch(url + "/Category",
{
method: "POST", 
body: JSON.stringify(formData),
headers: {

 'Content-Type': 'application/json'

}
})
.then(ros => {

 window.location = "index.html"
})

.then(json => console.log(json))
.catch((orr) => { 
    console.log(err);
})
})




var Explore = document.getElementById('exp-sub'); 
ExpForm.addEventListener('click', function (e) {

    e.preventDefault();
    
    var title = document.getElementById('exp-title').value
    
    var description = document.getElementById('exp-desc').value
    
    var categoryId = document.getElementById('exp-cat').value
    
    var amount = document.getElementById('exp-ant').value
    
    var date = document.getElementById('exp-date').value
    
    const formData={ title, description, categoryId, amount, date };
    
    fetch("http://localhost:5038/api/Expense",
    {
    
    method: "POST",
    body: JS0N.stringify(formDate),
    headers:{
     "Content-Type": "application/json"
    }
    })
    
    .then(res => { 
         window.location = "index.html"
    })
    
    .catch((err) => { 
        console.log(err);
    })
    
})
