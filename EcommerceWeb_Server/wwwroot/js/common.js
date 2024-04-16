window.ShowToastr = (type, message) => {
    if (type === "success") {
        toastr.success('');

    }
}

function ShowDeleteConfirmationModal() {
    $('#deleteConfirmationModal').modal('show');
}
function HideDeleteConfirmationModal() {
    $('#deleteConfirmationModal').modal('hide');
}