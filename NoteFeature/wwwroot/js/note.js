var listObj = {
    perPage: 6,
    page: 1,
    offset: 0,
    total: 0
}

const pagination = createPagination();  //Declare pagination object

var note = {
    init: () => {
        pagination.init("pagination", "paginationPerPageSelect", listObj.total, listObj.perPage, listObj.page, note.onPageChange)
        note.getNoteList(true);
    },
    getNoteList: function (isRender = false)
    {
        var data =
        {
            perPage: listObj.perPage,
            page: listObj.page,
            offset: listObj.offset,
            total: listObj.total
        }
        $.ajax(
            {
                type: "GET",
                url: "/Note/GetNoteList",
                data: data,
                success: function (res)
                {
                    if (!res) {
                        console.error("No response from server");
                        return;
                    }
                    if (res.success) {
                        const $container = $("#noteListContainer");
                        $container.empty();

                        console.log(res.notes)

                        if (res.notes && res.notes.length > 0) {
                            res.notes.forEach(n => {
                                const card = `
                                <div class="col-12 col-sm-6 col-md-4">
                                    <div class="card h-100 shadow-sm border-0 note-card">
                                        <div class="card-body d-flex flex-column p-4">
                                            <h5 class="card-title mb-2 user-select-none">
                                                <i class="bi bi-sticky text-warning"></i>
                                                ${n.title}
                                                <small class="text-muted">
                                                    ${n.updatedAt ? '<span class="badge bg-black">edit</span>' : ''}
                                                </small>
                                            </h5>
                                            <p class="card-text flex-grow-1 user-select-none">${n.content}</p>
                                            <div class="d-flex justify-content-between align-items-center mt-3">
                                                <small class="text-muted user-select-none">
                                                    <i class="bi bi-calendar3"></i> ${n.createdAt}
                                                </small>
                                                <div class="d-flex align-items-center">
                                                    <a href="/Note/Detail/${n.id}" class="btn btn-outline-primary btn-sm me-1" title="Detail">
                                                        <i class="bi bi-eye"></i>
                                                    </a>
                                                    <a href="/Note/Edit/${n.id}" class="btn btn-outline-primary btn-sm me-1" title="Edit">
                                                        <i class="bi bi-pencil"></i>
                                                    </a>
                                                    <button type="button" class="btn btn-outline-danger btn-sm" data-bs-toggle="modal" data-bs-target="#deleteModal" data-note-id="${n.Id}" data-note-title="${n.Title}" title="Delete">
                                                        <i class="bi bi-trash"></i>
                                                    </button>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>`;
                                $container.append(card);
                            });
                        } else {
                            $container.append('<div class="col-12"><p class="text-center">No notes available.</p></div>');
                        }

                        listObj.total = res.total || 0;
                        pagination.totalItems = listObj.total;
                        pagination.currentPage = listObj.page;
                        pagination.rowsPerPage = listObj.perPage;

                        console.log(document.getElementById("noteListContainer"));

                        if (isRender) {
                            pagination.render();
                        }
                    } else {
                        app.notify ? app.notify('Error', res.message || 'Server error') : alert(res.message || 'Server error');
                    }
                },
                error: function (xhr, status, err) {
                    console.error('AJAX error', status, err);
                }
            });
    },
    onPageChange(currentPage, rowsPerPage, offset) {
        listObj.page = currentPage;
        listObj.perPage = rowsPerPage;
        listObj.offset = (currentPage - 1) * rowsPerPage;
        note.getNoteList(true);
    }

}