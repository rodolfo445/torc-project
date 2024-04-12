function fetchBooks() {
  const fieldName = document.getElementById('fieldName').value;
  const value = document.getElementById('value').value;

  // Construct the URL with parameters
  const url = `http://localhost:5021/Books?FieldName=${fieldName}&Value=${value}`;

  fetch(url, { mode: 'cors' })
    .then(response => {
      if (!response.ok) {
        return response.json().then(error => {
          throw new Error(error.errors.Value[0] || 'Bad request');
        });
      }
      return response.json();
    })
    .then(data => {
      const tableBody = document.getElementById('booksTableBody');
      tableBody.innerHTML = '';

      data.forEach(book => {
        const row = document.createElement('tr');
        row.innerHTML = `
                    <td>${book.title}</td>
                    <td>${book.name}</td>
                    <td>${book.type}</td>
                    <td>${book.isbn}</td>
                    <td>${book.category}</td>
                    <td>${book.copies}</td>
                `;
        tableBody.appendChild(row);
      });
    })
    .catch(error => {
      console.log(error);
      alert('Bad request: ' + error.message);
    });
}
