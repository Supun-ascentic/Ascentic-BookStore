import * as React from 'react';
import { RouteComponentProps, withRouter } from 'react-router-dom';
import axios from 'axios';

export interface IValues {
    [key: string]: any;
}
export interface IFormState {
    id: number,
    book: any;
    values: IValues[];
    submitSuccess: boolean;
    loading: boolean;
}

class EditBook extends React.Component<RouteComponentProps<any>, IFormState> {
    constructor(props: RouteComponentProps) {
        super(props);
        this.state = {
            id: this.props.match.params.id,
            book: {},
            values: [],
            loading: false,
            submitSuccess: false,
        }
    }

    public componentDidMount(): void {
        axios.get(`https://localhost:44359/api/Book/${this.state.id}`).then(data => {
            this.setState({ book: data.data });
            this.setState({ values: data.data });
        })
    }

    private processFormSubmission = async (e: React.FormEvent<HTMLFormElement>): Promise<void> => {
        e.preventDefault();
        this.setState({ loading: true });
        let config = {
            headers: {
                'Content-Type': 'application/json; charset=utf-8',
                'Access-Control-Allow-Origin': '*',
            }
        }
        axios.put(`https://localhost:44359/api/Book/${this.state.id}`, this.state.values,config).then(data => {
            this.setState({ submitSuccess: true, loading: false })
            setTimeout(() => {
                this.props.history.push('/');
            }, 1500)
        })
    }

    private setValues = (values: IValues) => {
        this.setState({ values: { ...this.state.values, ...values } });
    }
    private handleInputChanges = (e: React.FormEvent<HTMLInputElement>) => {
        e.preventDefault();
        this.setValues({ [e.currentTarget.id]: e.currentTarget.value })
    }


    public render() {
        const { submitSuccess, loading } = this.state;
        return (
            <div className="App">
                {this.state.book &&
                    <div>
                        < h1 > Book List Management App</h1>
                        <p> Built with React.js and TypeScript </p>

                        <div>
                            <div className={"col-md-12 form-wrapper"}>
                                <h2> Edit Book </h2>
                                {submitSuccess && (
                                    <div className="alert alert-info" role="alert">
                                        Book details has been edited successfully </div>
                                )}
                                <form id={"create-post-form"} onSubmit={this.processFormSubmission} noValidate={true}>
                                    <div className="form-group col-md-12">
                                        <label htmlFor="title"> Title </label>
                                        <input type="text" id="title" defaultValue={this.state.book.title} onChange={(e) => this.handleInputChanges(e)} name="title" className="form-control" placeholder="Enter book title" />
                                    </div>
                                    <div className="form-group col-md-12">
                                        <label htmlFor="categoryId"> Category Id </label>
                                        <input type="text" id="categoryId" defaultValue={this.state.book.categoryId} onChange={(e) => this.handleInputChanges(e)} name="categoryId" className="form-control" placeholder="Enter book category Id" />
                                    </div>
                                    <div className="form-group col-md-12">
                                        <label htmlFor="price"> Price </label>
                                        <input type="text" id="price" defaultValue={this.state.book.price} onChange={(e) => this.handleInputChanges(e)} name="price" className="form-control" placeholder="Enter book price" />
                                    </div>
                                    <div className="form-group col-md-12">
                                        <label htmlFor="description"> Description </label>
                                        <input type="text" id="description" defaultValue={this.state.book.description} onChange={(e) => this.handleInputChanges(e)} name="description" className="form-control" placeholder="Enter Description" />
                                    </div>
                                    <div className="form-group col-md-4 pull-right">
                                        <button className="btn btn-success" type="submit">
                                            Edit Book </button>
                                        {loading &&
                                            <span className="fa fa-circle-o-notch fa-spin" />
                                        }
                                    </div>
                                </form>
                            </div>
                        </div>
                    </div>
                }
            </div>
        )
    }
}
export default withRouter(EditBook)