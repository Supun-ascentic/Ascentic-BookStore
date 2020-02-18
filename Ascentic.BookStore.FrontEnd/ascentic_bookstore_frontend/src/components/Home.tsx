import * as React from 'react';
import { Link, RouteComponentProps } from 'react-router-dom';
import axios from 'axios';

interface IState {
    books: any[];
}

export default class Home extends React.Component<RouteComponentProps, IState> {
    constructor(props: RouteComponentProps) {
        super(props);
        this.state = { books: [] }
    }
    public componentDidMount(): void {
        axios.get(`https://localhost:44359/api/Book/get_books_with_all_Details`).then(data => {
            this.setState({ books: data.data })
        })
    }
    public deleteBook(id: number) {
        axios.delete(`https://localhost:44359/api/Book/${id}`).then(data => {
            const index = this.state.books.findIndex(book => book.id === id);
            this.state.books.splice(index, 1);
            this.props.history.push('/');
        })
    }


    public render() {
        const books = this.state.books;
        return (
            <div>
                {books.length === 0 && (
                    <div className="text-center">
                        <h2>No Books found at the moment</h2>
                    </div>
                )}
                <div className="container">
                    <div className="row">
                        <table className="table table-bordered">
                            <thead className="thead-light">
                                <tr>
                                    <th scope="col">Title</th>
                                    <th scope="col">Author</th>
                                    <th scope="col">Catagory</th>
                                    <th scope="col">Price</th>
                                    <th scope="col">Description</th>
                                </tr>
                            </thead>
                            <tbody>
                                {books && books.map(book =>
                                    <tr key={book.id}>
                                        <td>{book.title}</td>
                                        <td>
                                             {book.bookAuthor && book.bookAuthor.map((authorData: { author: { name: any; }; }) =>
                                                authorData.author.name
                                            )}
                                        
                                        </td>
                                        <td>{book.category.categoryName}</td>
                                        <td>{book.price}</td>
                                        <td>{book.description}</td>
                                        <td>
                                            <div className="d-flex justify-content-between align-items-center">
                                                <div className="btn-group" style={{ marginBottom: "20px" }}>
                                                    <Link to={`edit/${book.id}`} className="btn btn-sm btn-outline-secondary">Edit Book </Link>
                                                    <button className="btn btn-sm btn-outline-secondary" onClick={() => this.deleteBook(book.id)}>Delete Book</button>
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                )}
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        )
    }
}